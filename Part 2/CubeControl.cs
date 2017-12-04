using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        if (MainControl.actionStart == true)
        {
            Destroy(this.gameObject);
        }
    }
}
