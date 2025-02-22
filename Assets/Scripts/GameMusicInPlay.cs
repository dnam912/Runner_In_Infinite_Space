using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusicInPlay : MonoBehaviour
{
    public static GameMusicInPlay instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EffectMode")
        {
            // GameMusicInMenu.instance.GetComponent<AudioSource>().Pause();
            Destroy(gameObject);
        } 
        
        /*else
        {
            GameMusicInMenu.instance.GetComponent<AudioSource>().Play();
        }*/

        if (SceneManager.GetActiveScene().name == "MenuMode" ||
            SceneManager.GetActiveScene().name == "WinMode" ||
            SceneManager.GetActiveScene().name == "LoseMode")
        {
            Destroy(gameObject);
        }
    }
}
