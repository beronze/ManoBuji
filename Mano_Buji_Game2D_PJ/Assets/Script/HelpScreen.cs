using UnityEngine;
using System.Collections;

public class HelpScreen : MonoBehaviour {

    public GameObject P_Screen;
    // Use this for initialization
    void Start()
    {
        P_Screen.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            P_Screen.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            P_Screen.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
