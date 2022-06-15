using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject pressE;


    public Transform PlayerPoint;
    public float PlayerRange = 0.5f;
    public LayerMask Doorlayers; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        pressE.SetActive(false);


        DitectDoor();
        
    }


    void DitectDoor()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(PlayerPoint.position, PlayerRange, Doorlayers);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i] != null)
            {
               pressE.SetActive(true);
                

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("selection");
                }
            }

        }
    }


}
