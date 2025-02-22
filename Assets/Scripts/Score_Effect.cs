using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.ShaderGraph.Internal;

public class Score_Effect : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;

    float distance = 0;
    static public float scoreValue_start = 0;
    static public float scoreValue_effect = 0;

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
                scoreValue_effect = distance;
            }
            
            // Add to score after respawning
            if (ColliderZone.respawned)
            {   
                scoreValue_effect += distance;
            }

            scoreText.text = scoreValue_effect.ToString("0");
        }

    }
}
