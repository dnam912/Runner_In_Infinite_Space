using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.ShaderGraph.Internal;

public class ScoreEffectMode : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;

    float distance = 0;
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
                scoreValue = distance;

                if (Portals_EffectMode.isTeleporting == true)
                {

                }
            }
            
            /*
            if (Timer.stopTimer == true)
            {
                Score.scoreValue += scoreValue;
            }*/

            /*
            // Add to score after respawning
            if (ColliderZone.respawned)
            {
                scoreValue = distance;
                scoreValue += distance;
            } */

            scoreText.text = scoreValue.ToString("0");
        }

    }
}
