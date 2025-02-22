using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.ShaderGraph.Internal;

public class Score_Start : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;

    float distance = 0;
    static public float scoreValue_start = 0;
    float scoreValue = 0;

    void Update()
    {
        if (!ColliderZone.isGameOver)
        {
            // Check distance traveled by player without decreasing
            if (distance < player.position.z)
            {
                distance = player.position.z;
            }

            // Intial score before respawning
            if (!ColliderZone.respawned)
            {
                scoreValue_start = distance;
                scoreValue = scoreValue_start;
            }
            
            // Add to score after respawning
            if (ColliderZone.respawned)
            {   
                scoreValue_start += distance;
                scoreValue = scoreValue_start;

                Debug.Log("ColliderZone.respawned: " + scoreValue);
            }

            if (Portals_EffectMode.isAdded == true)
            {
                scoreValue_start = (Portals_EffectMode.score_effect + Portals_EffectMode.score_start);
                scoreValue = scoreValue_start;
                Debug.Log("score_effect + score_start: " + scoreValue);
            }


            /*
            if (Timer.stopTimer == false)
            {
                // scoreValue += distance;
                // scoreValue_start = distance;

               
                // Portals_EffectMode.score_effect = scoreValue_effect;
                // scoreValue_start = Portals_EffectMode.score;
                scoreValue_start = (Portals_EffectMode.score_effect + Portals_EffectMode.score_start);
                Debug.Log("scoreValue_start" + scoreValue_start);


                Debug.Log("isTeleporting == true");

            }*/

            scoreText.text = scoreValue.ToString("0");
        }

    }
}
