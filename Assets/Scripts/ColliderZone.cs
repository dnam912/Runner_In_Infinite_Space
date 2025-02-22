using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderZone : MonoBehaviour
{
    [SerializeField] private float delayTime = 3.0f;

    public static bool isGameOver;
    public static bool isGameSuccess;
    public static bool respawned;
    public GameObject gameOverScreen;
    public GameObject gameSuccessScreen;


    private void Awake()
    {
        isGameOver = false;
        isGameSuccess = false;
        respawned = false;
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isGameOver == true)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false; // Destroy player object
            gameOverScreen.SetActive(true);
        }

        if (collision.transform.tag == "GameSuccess")
        {
            isGameSuccess = true;
            gameSuccessScreen.SetActive(true);
            StartCoroutine(delayLoadingScene()); // Delay loading scene

        }

        if (respawned)
        {
            respawned = true;
        }
    }

    IEnumerator delayLoadingScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("WinMode");
    }

}
