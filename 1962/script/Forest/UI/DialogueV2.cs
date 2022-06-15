using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueV2 : MonoBehaviour
{
    
    
    
    
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;


    public GameObject pressT;
    public GameObject popUP;
    public GameObject dialogue;

    public GameObject cutscenImg;

    private int index = 0;


 


    public void StartDialogue()
    {
        pressT.SetActive(false);
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }
   IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {  
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            textComponent.text = string.Empty;
            popUP.SetActive(true); 
            dialogue.SetActive(false);

        }
    }

  public  void next()
    {
        cutscenImg.SetActive(false);

            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {   
                
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        
    }


}
