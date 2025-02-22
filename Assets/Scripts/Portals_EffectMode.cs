using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;

/* REFERENCE
 * Author: Code Cyber
 * https://youtu.be/cJRAXIo2o10?si=E2EvQSGqrvhhSx1X
 */

public class Portals_EffectMode : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform transportPortal;
    
    static public float score_start = 0;
    static public float score_effect = 0;

    public static bool isTeleporting;
    public static bool isAdded;
    Vector3 savePosition;


    // Update is called once per frame
    void Start()
    {
        isTeleporting = false;
        isAdded = false;
    }

    void Update()
    {
        if (Timer.stopTimer == true)
        {
            isTeleporting = false;
            Timer.stopTimer = false;

            StartCoroutine(Teleport());
            // transportPortal.transform.position = savePosition;

            score_effect = Score_Effect.scoreValue_effect;
            Debug.Log("Portal effect mode -> effect: " + score_effect);

            isAdded = true;
            // Score_Start.scoreValue_start = (score_effect + score_start);

            Debug.Log("Entered EffectMode");
        }

        isAdded = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isTeleporting = true;

            score_start = Score_Start.scoreValue_start;
            Debug.Log("Portal effect mode -> start: " + score_start);

            // SceneInfo.DontDestroyOnLoad(collision.gameObject);
            // SceneInfo.LoadScene(name);
            // StartCoroutine(Teleport());


            SceneManager.LoadScene("EffectMode");
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isTeleporting = false;
            Debug.Log("Exited EffectMode");
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);


        player.transform.position = new Vector3
        (
            transportPortal.transform.position.x,
            transportPortal.transform.position.y,
            transportPortal.transform.position.z + 3
        );

        savePosition = player.transform.position;

        Physics.SyncTransforms();
    }
}
