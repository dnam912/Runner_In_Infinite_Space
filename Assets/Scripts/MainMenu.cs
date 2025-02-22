using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // SceneManager.LoadScene("StartMode");
    }

    public void HowtoPlayButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credit");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MenuMode");
    }

    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
