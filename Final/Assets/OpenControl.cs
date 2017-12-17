using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpenControl : MonoBehaviour {

    public Text scoreText;

    public void Start()
    {
        
    }

    public void SwitchScenes (int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Update()
    {
        scoreText.text = "Score: " + MainControl.score;
    }
}
