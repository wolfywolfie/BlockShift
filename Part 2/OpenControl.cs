using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenControl : MonoBehaviour {

    public void Start()
    {
        
    }

    public void SwitchScenes (int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
