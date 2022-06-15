using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitectPerson : MonoBehaviour
{
    public GameObject pressT;
    public GameObject dialogue;
    public GameObject cutscreen;
    public GameObject waypoint;
    public GameObject PauseMenu;



    public GameObject cam2;

    public GameObject player;
    public GameObject person;
    


    public Transform PlayerPoint;
    public float PlayerRange = 0.5f;
    public LayerMask personlayers; // for define which objects is person and wich not
    

    // Start is called before the first frame update
    void Start()
    {
      //Cursor.visible = false;
      //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        pressT.SetActive(false);
        PauseMenu.GetComponent<Pause>().enabled = true;
        Detect();
        
    }
    void Detect()
    {
        //Detect person if it is on  range of player
         Collider[] hitEnemies = Physics.OverlapSphere(PlayerPoint.position, PlayerRange, personlayers);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
         
            if (hitEnemies[i] != null)
            {

                // show press T ui
                pressT.SetActive(true);
                PauseMenu.GetComponent<Pause>().enabled = false;

                if (Input.GetKeyDown(KeyCode.T))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                   


                    waypoint.SetActive(false);

                    cutscreen.SetActive(true);
                    person.GetComponent<WayPoint>().enabled = false;
                    



                    player.transform.position = new Vector3(67, 31, 87);
                    


                    
                   
                    cam2.SetActive(true);



                   
                   FindObjectOfType<PersonAnim>().sitting();

                     dialogue.SetActive(true);
                     FindObjectOfType<DialogueV2>().StartDialogue();

                    player.SetActive(false);


                }


                   
            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (PlayerPoint == null)
            return;

        Gizmos.DrawSphere(PlayerPoint.position, PlayerRange);
    }



}
