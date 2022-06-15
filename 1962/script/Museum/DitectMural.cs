using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitectMural : MonoBehaviour
{
    public GameObject[] Buttons;
    public GameObject[] Cameras;
    public GameObject pressM;
    public GameObject playerld;




    public Transform PlayerPoint;
    public float PlayerRange = 0.5f;
    public LayerMask Murallayers; // for define which objects Mural and wich not




    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(6);
    }

    // Update is called once per frame
    void Update()
    {
        pressM.SetActive(false);
        Ditect();
    }

    void Ditect()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(PlayerPoint.position, PlayerRange, Murallayers);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            if (hitEnemies[i] != null)
            {
                pressM.SetActive(true);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;



                    switch (hitEnemies[i].name)
                    {
                        case "Paint1":
                            {
                                Cameras[0].SetActive(false);
                                Cameras[1].SetActive(true);

                                pressM.SetActive(false);

                                Buttons[0].SetActive(true);


                                playerld.transform.position = new Vector3(2, -2, -1);
                                playerld.SetActive(false);


                            } break;
                            
                            
                            
                        case "Paint2":
                            {
                                Cameras[0].SetActive(false);
                                Cameras[2].SetActive(true);

                                pressM.SetActive(false);


                                Buttons[1].SetActive(true);


                                playerld.transform.position = new Vector3(1, -2, 7);
                                playerld.SetActive(false);

                            }
                            break;



                            
                        case "Paint3":
                            {
                                Cameras[0].SetActive(false);
                                Cameras[3].SetActive(true);

                                pressM.SetActive(false);


                                Buttons[2].SetActive(true);


                                playerld.transform.position = new Vector3(1, -2, 15);
                                playerld.SetActive(false);

                            }
                            break;



                           
                        case "Paint4":
                            {
                                Cameras[0].SetActive(false);
                                Cameras[4].SetActive(true);

                                pressM.SetActive(false);

                                Buttons[3].SetActive(true);



                                playerld.transform.position = new Vector3(2, -2, 22);
                                playerld.SetActive(false);

                            }
                            break;

                            
                            
                        case "Paint5":
                            {
                                Cameras[0].SetActive(false);
                                Cameras[5].SetActive(true);

                                pressM.SetActive(false);

                                Buttons[4].SetActive(true);


                                playerld.transform.position = new Vector3(1, -2, 14);
                                playerld.SetActive(false);

                            }
                            break;


                            
                        case "Paint6":
                            {
                                Cameras[0].SetActive(false);
                                Cameras[6].SetActive(true);

                                pressM.SetActive(false);


                                Buttons[5].SetActive(true);


                                playerld.transform.position = new Vector3(1, -2, 7);
                                playerld.SetActive(false);

                            }
                            break;

                            
                            


                    }

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
