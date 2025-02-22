using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);

            Debug.Log("gameOverScreen_Management");
        }

        if (isGameSuccess) {
            gameSuccessScreen.SetActive(true);
        }

        if (respawned)
        {
            respawned = true;
            Debug.Log("respawn_Management");
        }
    }

}
