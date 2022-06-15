using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class quality : MonoBehaviour
{

    public TMP_Dropdown dropdown;




    // Start is called before the first frame update
    void Start()
    {
        dropdown.value = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ChangeLevel(int Value)
    {
        switch (Value)
        {
            case 0:
                {
                    QualitySettings.SetQualityLevel(5);
                }
                break;

            case 1:
                {
                    QualitySettings.SetQualityLevel(3);
                }
                break;

            case 2:
                {
                    QualitySettings.SetQualityLevel(2);
                }
                break;

            case 3:
                {
                    QualitySettings.SetQualityLevel(1);
                }
                break;
        }

    }


    public void changeL()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void changeM()
    {
        QualitySettings.SetQualityLevel(1);
    }

    public void changeH()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void changeU()
    {
        QualitySettings.SetQualityLevel(5);
    }


}
