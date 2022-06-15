using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testSwitch : MonoBehaviour
{

    public void GoBack()
    {
        SceneManager.LoadScene("selection");
    }
}
