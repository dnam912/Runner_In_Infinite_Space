using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal_2 : MonoBehaviour
{
    public Transform player;
    public Transform Receiver;

    private bool playerIsOverlapping = false;
    float dotProduct;
    float rotationDiff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            dotProduct = Vector3.Dot(transform.up, portalToPlayer);
        }

        if (dotProduct < 0f)
        {
            rotationDiff = -Quaternion.Angle(transform.rotation, Receiver.rotation);
            rotationDiff += 180;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
