using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFirstShow : MonoBehaviour
{
    public GameObject FirstPerson;
    public GameObject idlleV2;
    public GameObject person;
    public GameObject PauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.GetComponent<Pause>().enabled = false;
        StartCoroutine(WaitCamera());

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator WaitCamera()
    {

        yield return new WaitForSeconds(45);
        FirstPerson.SetActive(true);
        person.SetActive(true);
        idlleV2.SetActive(false);
        PauseMenu.GetComponent<Pause>().enabled = true;
        gameObject.SetActive(false);

    }

}
