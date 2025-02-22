using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndEffectMode : MonoBehaviour
{
    [SerializeField] private float delayTime = 3.0f;
    public GameObject boxCollidered;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            boxCollidered.SetActive(true);
            StartCoroutine(delayLoadingScene());
        }
    }

    IEnumerator delayLoadingScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("StartMode");
    }
}
