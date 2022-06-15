using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PopUP : MonoBehaviour
{

    public GameObject pressT;
    public GameObject dialogue;
    public GameObject popUp;
    public GameObject waypoint;
    public GameObject PauseMenu;


    public GameObject cam2;
    public GameObject firstP;

    public GameObject person;


    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
    }

    // Update is called once per frame



    public void NoChoice()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        firstP.SetActive(true);

        cam2.SetActive(false);

        PauseMenu.GetComponent<Pause>().enabled = true;

        popUp.SetActive(false);
        waypoint.SetActive(true);
        person.GetComponent<WayPoint>().enabled = true;


        FindObjectOfType<PersonAnim>().standing();

    }

    public void YesChoice()
    {
       SceneManager.LoadScene("selection");
    }

    
}
