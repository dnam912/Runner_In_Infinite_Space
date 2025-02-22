using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

/* REFERENCE
 * Billy Man
 * https://youtu.be/ha6U8jHl9ak?si=2IOdk7Za7uvReDod
 */

public class GameMusicInMenu : MonoBehaviour
{
    public static GameMusicInMenu instance;

    void Awake()
    {
        if (instance != null ||
            SceneManager.GetActiveScene().name == "StartMode")
        {
            Destroy(gameObject);

        } else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


    }

    void Update()
    {
        
        
    }
}
