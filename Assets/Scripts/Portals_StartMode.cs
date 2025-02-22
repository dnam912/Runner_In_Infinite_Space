using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

/* REFERENCE
 * Author: Code Cyber
 * https://youtu.be/cJRAXIo2o10?si=E2EvQSGqrvhhSx1X
 */

public class Portals_StartMode : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform transportPortal;
    public static bool isTeleporting;


    // Update is called once per frame
    void Start()
    {
        isTeleporting = false;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isTeleporting = true;
            StartCoroutine(Teleport());
            Debug.Log("Entered Portal");

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isTeleporting = false;
            Debug.Log("Exited Portal");

        }

    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);

        player.transform.position = new Vector3
        (
            transportPortal.transform.position.x,
            transportPortal.transform.position.y,
            transportPortal.transform.position.z + 2
        );
        Physics.SyncTransforms();
    }
}
