using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* REFERENCE
 * Author: Muddy Wolf
 * https://youtu.be/GeeKVPwM5Xw?si=RKyHXJod2tKFA7VC
 */


public class Portal_Draft : MonoBehaviour
{
    [SerializeField] private float timeToTeleport = 1f;
    [SerializeField] private Transform portalTeleportLocation;
    private float teleportTimer;
    private bool isTeleporting;

    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        teleportTimer = timeToTeleport;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (player && isTeleporting)
        {
            if (teleportTimer > 0f)
            {
                teleportTimer -= Time.deltaTime;
            } else
            {
                Teleport();
            }
        }
    }

    private void Teleport()
    {
        player.transform.position = portalTeleportLocation.position;
        teleportTimer = timeToTeleport;
        isTeleporting = false;
        player = null;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            isTeleporting = true;
            player = collision.gameObject;

            Debug.Log("Entered Portal");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            isTeleporting = false;
            player = null;
            teleportTimer = timeToTeleport;

            Debug.Log("Exited Portal");
        }
    }
}
