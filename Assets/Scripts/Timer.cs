using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* REFERENCE
 * CatoDevs
 * https://youtu.be/-dKkAzCrBOY?si=TR6gfIMTM4fdzgN2
 */

public class Timer : MonoBehaviour
{
    public Slider slider;
    public float time;
    static public bool stopTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = time;
        slider.value = time;
        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(StartTheTimerTicker());
    }

    IEnumerator StartTheTimerTicker()
    {
        while (stopTimer == false)
        {
            time -= Time.deltaTime;
            yield return new WaitForSeconds(0.1f);


            if (time <= 0)
            {
                stopTimer = true;
                SceneManager.LoadScene("StartMode");
                
            }

            if (stopTimer == false)
            {
                slider.value = time;
                
            }
        }
    }
    
    public void isStopped()
        {
            stopTimer = true;
        }
}
