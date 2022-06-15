using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class info : MonoBehaviour
{
    public GameObject[] Cameras;
    public GameObject playerld;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        



    }




    public void ShowInfo(GameObject InfoUI)
    {
        InfoUI.SetActive(true);
        gameObject.SetActive(false);//button
    }

    public void UnshowInfo(GameObject InfoUI)
    {
        switshCameras();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InfoUI.SetActive(false);

      
    }


    public void switshCameras()
    {

        
        playerld.SetActive(true);
        Cameras[0].SetActive(true);


        Cameras[1].SetActive(false);
        Cameras[2].SetActive(false);
        Cameras[3].SetActive(false);
        Cameras[4].SetActive(false);
        Cameras[5].SetActive(false);
        Cameras[6].SetActive(false);
    }
}
