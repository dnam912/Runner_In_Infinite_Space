using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeFill : MonoBehaviour
{
    public Image hearts;
    static public float life = 1;
    float maxLife = 1;


    // Start is called before the first frame update
    void Start()
    {
        hearts.fillAmount = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        // The life amount is subtracted when the respawn counter decremented in RespawnPlayer script

        if (ColliderZone.respawned == true)
        {
            hearts.fillAmount = life; 
            Debug.Log(hearts.fillAmount);

        }
        if (RespawnPlayer.counter == 0)
        {
            hearts.fillAmount = 0;
        }
        
        ColliderZone.respawned = false;

    }



}
