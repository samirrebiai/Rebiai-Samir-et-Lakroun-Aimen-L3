using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseGameUi;


    public GameObject firstPeson;
    public GameObject CamfirstPeson;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        firstPeson.GetComponent<PlayerMovement>().speed = 2.2f;
        CamfirstPeson.GetComponent<MouseLook>().mouseSensitivity = 80f;



        PauseGameUi.SetActive(false);
        //Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Paused()
    {
        Resume();
        Cursor.lockState = CursorLockMode.None;
        firstPeson.GetComponent<PlayerMovement>().speed = 0f;
        CamfirstPeson.GetComponent<MouseLook>().mouseSensitivity = 0f;


        PauseGameUi.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
