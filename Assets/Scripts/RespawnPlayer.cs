using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float delayTime = 3.0f;
    public GameObject player;
    static public int counter = 5; // Counting respawn & life hearts


    private void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision == player.GetComponent<Collider>()) // This condition prevents OnTriggerEnter() triggers twice at once
        {
            // Debug.Log("Collied with: " + collision.gameObject.name);
            ColliderZone.respawned = true;
            
            player.transform.position = respawnPoint.position;
            Physics.SyncTransforms(); // Return player to the original position

            LifeFill.life -= 0.2f; // Subtract the number of life heart
            counter--;
        }
        
        if (counter == 0)
        {
            LifeFill.life = 0.0f; // The life heart becomes zero
            
            ColliderZone.respawned = false;
            ColliderZone.isGameOver = true;

            StartCoroutine(delayLoadingScene()); // Delay loading scene
        }
    }

    IEnumerator delayLoadingScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("LoseMode");
    }
}
