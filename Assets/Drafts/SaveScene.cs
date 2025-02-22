using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene: MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log(gameObject.scene.name);
    }
}
