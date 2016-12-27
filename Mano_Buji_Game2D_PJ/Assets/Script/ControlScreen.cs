using UnityEngine;
using System.Collections;

public class ControlScreen : MonoBehaviour {
    public GameObject BlackScreen;
	// Use this for initialization
	void Start () {
        BlackScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            BlackScreen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            BlackScreen.SetActive(false);
        }
        
	}
}
