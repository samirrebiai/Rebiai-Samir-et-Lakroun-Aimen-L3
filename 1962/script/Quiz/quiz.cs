using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using TMPro;
using System.Linq;
using System.Data.Common;
using System.Data;
using UnityEditor;
using Random = UnityEngine.Random;




using System.IO;
public class quiz : MonoBehaviour
{
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI[] ButtonTextA;
    public Button[] ButtonA;
    
    public GameObject ButtonStart;
    public GameObject UiQuiz;


    public GameObject winUI;
    public TextMeshProUGUI ScoreText;
    public GameObject[] stars;

    public TextMeshProUGUI NumQst;


    int TabBLenght;
    int[] index = new int[10];

    int i,L=1,m;

    int score;

    int numSOl = 0;

    // Start is called before the first frame update

     void Start()
    {
        
        StartCoroutine(GetTabLenth());
        
    }



    public void StartGame()
    {
        score = 0;
        L = 1;
        NumQst.text = L.ToString();

        UiQuiz.SetActive(true);
        ButtonStart.SetActive(false);

        Shuffle();
        i = index[0];


        StartCoroutine(Question());//recperate qst from DB and print them
        StartCoroutine(Answer1());//recperate Ans1 from DB and print them
        StartCoroutine(Answer2());//recperate Ans2 from DB and print them
        StartCoroutine(Answer3());//recperate Ans3 from DB and print them
        StartCoroutine(Answer4());//recperate Ans4 from DB and print them
        StartCoroutine(SoulOrder());//recperate solorder from DB and print them

        
       


    }


    IEnumerator WaitS()
    {

        yield return new WaitForSeconds(1f);
        StartCoroutine(Question());
        StartCoroutine(Answer1());
        StartCoroutine(Answer2());
        StartCoroutine(Answer3());
        StartCoroutine(Answer4());
        StartCoroutine(SoulOrder());
        BtnDefault();
        ButtonA[0].enabled = true;
        ButtonA[1].enabled = true;
        ButtonA[2].enabled = true;
        ButtonA[3].enabled = true;
        NumQst.text = L.ToString();

    }





    IEnumerator GetTabLenth()
    {
        WWW request = new WWW("http://localhost/1962%20WebSite/PHP/Question.php");
        yield return request;

        string[] webResults = request.text.Split('\t');//tafrik bin les qst or Ans.....
        TabBLenght = webResults.Length - 2;//-1 ta3 \t lakhra w -1 ta3 lawla

    }







    IEnumerator Question()//recperate qst from DB and print them
    {
        WWW request = new WWW("http://localhost/1962%20WebSite/PHP/Question.php");
        yield return request;
       
  

        string[] webResults = request.text.Split('\t');

        

        if (i < webResults.Length-1)
        {
            string question = webResults[i];

           
            QuestionText.text = question;
           

        }

    }


    IEnumerator Answer1()
    {
        WWW request = new WWW("http://localhost/1962%20WebSite/PHP/Answer1.php");
        yield return request;


        string[] webResults1 = request.text.Split('\t');
        if (i < webResults1.Length - 1)
        {
          string answer1 = webResults1[i];

           
            ButtonTextA[0].text = answer1; 
        }    
    }

    IEnumerator Answer2()
    {
        WWW request = new WWW("http://localhost/1962%20WebSite/PHP/Answer2.php");
        yield return request;


        string[] webResults2 = request.text.Split('\t');
        if (i < webResults2.Length - 1)
        {
            string answer2 = webResults2[i];
    

            ButtonTextA[1].text = answer2;
        }
    }

    IEnumerator Answer3()
    {
        WWW request = new WWW("http://localhost/1962%20WebSite/PHP/Answer3.php");
        yield return request;


        string[] webResults3 = request.text.Split('\t');
        if (i < webResults3.Length - 1)
        {
            string answer3 = webResults3[i];
          

            ButtonTextA[2].text = answer3;
        }
    }

    IEnumerator Answer4()
    {
        WWW request = new WWW("http://localhost/1962%20WebSite/PHP/Answer4.php");
        yield return request;


        string[] webResults4 = request.text.Split('\t');
        if (i < webResults4.Length - 1)
        {
            string answer4 = webResults4[i];

            ButtonTextA[3].text = answer4;
        }
    }


    IEnumerator SoulOrder()
    {
        WWW request = new WWW("http://localhost/1962%20WebSite/PHP/Soulorder.php");
        yield return request;
        
        string[] webResults5 = request.text.Split('\t');
        if (i < webResults5.Length - 1)
        {
            string soulorder = webResults5[i];
            numSOl = int.Parse(webResults5[i]);

          
        }


    }

    public void IdNum(int L)// affichage de wrong and right Qst , L is the iD of Button
    {
        

       if(numSOl == L) //right QST
        {
            score++;

            switch (L)
            {
                case 1:
                    {
                        ButtonA[0].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[0].GetComponent<Image>().color = new Color(0,255,0);
                        break;
                    }
                case 2:
                    {
                        ButtonA[1].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[1].GetComponent<Image>().color = new Color(0, 255, 0);
                        break;
                    }
                case 3:
                    {
                        ButtonA[2].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[2].GetComponent<Image>().color = new Color(0, 255, 0);
                        break;
                    }
                case 4:
                    {
                        ButtonA[3].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[3].GetComponent<Image>().color = new Color(0, 255, 0);
                        break;
                    }

            }
        }
        else //wrong QST
        {


           WrongChoice(L);//affichage the Wrong QST
            switch (numSOl)//affichage the right QST
            {

                case 1:
                    {
                        ButtonA[0].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[0].GetComponent<Image>().color = new Color(0, 255, 0);
                        break;
                    }
                case 2:
                    {
                        ButtonA[1].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[1].GetComponent<Image>().color = new Color(0, 255, 0);
                        break;
                    }
                case 3:
                    {
                        ButtonA[2].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[2].GetComponent<Image>().color = new Color(0, 255, 0);
                        break;
                    }
                case 4:
                    {
                        ButtonA[3].transform.GetChild(2).gameObject.SetActive(true);
                        ButtonA[3].GetComponent<Image>().color = new Color(0, 255, 0);
                        break;
                    }


            }
        }

    }

   public void WrongChoice(int Btnindex)
    {
        switch (Btnindex)
        {
            case 1:
                {
                    ButtonA[0].transform.GetChild(1).gameObject.SetActive(true);
                    ButtonA[0].GetComponent<Image>().color = new Color(255, 0, 0);
                    break;
                }
            case 2:
                {
                    ButtonA[1].transform.GetChild(1).gameObject.SetActive(true);
                    ButtonA[1].GetComponent<Image>().color = new Color(255, 0, 0);
                    break;
                }
            case 3:
                {
                    ButtonA[2].transform.GetChild(1).gameObject.SetActive(true);
                    ButtonA[2].GetComponent<Image>().color = new Color(255, 0, 0);
                    break;
                }
            case 4:
                {
                    ButtonA[3].transform.GetChild(1).gameObject.SetActive(true);
                    ButtonA[3].GetComponent<Image>().color = new Color(255, 0, 0);
                    break;
                }

        }

    }
    


    public void BtnDefault()// color deffult
    {
        ButtonA[0].GetComponent<Image>().color = new Color(255, 255, 255);
        ButtonA[1].GetComponent<Image>().color = new Color(255, 255, 255);
        ButtonA[2].GetComponent<Image>().color = new Color(255, 255, 255);
        ButtonA[3].GetComponent<Image>().color = new Color(255, 255, 255);

        ButtonA[0].transform.GetChild(1).gameObject.SetActive(false);
        ButtonA[1].transform.GetChild(1).gameObject.SetActive(false);
        ButtonA[2].transform.GetChild(1).gameObject.SetActive(false);
        ButtonA[3].transform.GetChild(1).gameObject.SetActive(false);

        ButtonA[0].transform.GetChild(2).gameObject.SetActive(false);
        ButtonA[1].transform.GetChild(2).gameObject.SetActive(false);
        ButtonA[2].transform.GetChild(2).gameObject.SetActive(false);
        ButtonA[3].transform.GetChild(2).gameObject.SetActive(false);



    }

    public void next()
    {

        StartCoroutine(WaitS());
        ButtonA[0].enabled = false;
        ButtonA[1].enabled = false;
        ButtonA[2].enabled = false;
        ButtonA[3].enabled = false;

        if (L < 10)
        {   
            i = index[L];
            L++;
            
        }
        else
        {
            ButtonA[0].enabled = false;
            ButtonA[1].enabled = false;
            ButtonA[2].enabled = false;
            ButtonA[3].enabled = false;
            StartCoroutine(WinWait());
        }

        
    }

    IEnumerator WinWait()
    {

        yield return new WaitForSeconds(1f);
        Win();


    }
    public void Win()
    {
        UiQuiz.SetActive(false);
        winUI.SetActive(true);

       if (score >= 3)
        {
            stars[0].SetActive(true);
        }
        if (score >= 6)
        {
            stars[1].SetActive(true);
        }

        if (score == 10 )
        {
            stars[2].SetActive(true);
        }


        ScoreText.text = score.ToString();



    }

    public void Restar()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);

        ButtonA[0].enabled = true;
        ButtonA[1].enabled = true;
        ButtonA[2].enabled = true;
        ButtonA[3].enabled = true;

        UiQuiz.SetActive(true);
        winUI.SetActive(false);
        StartGame();


    }




    public int FirstTabGen(int M)
       {
          int[] bnum = new int[TabBLenght];
          int k = 1;
           for (m = 0; m < TabBLenght; m++)
           {
               bnum[m] = k;
               k++;
            
        }
          return bnum[M];
       }







     void  Shuffle()
     {
        Debug.Log(TabBLenght);

        int[] bnum1 = new int[TabBLenght];

        int z = 0;
        for (z = 0; z < TabBLenght; z++)
        {
            bnum1[z] = FirstTabGen(z);
           
        }
        
        int rowcheker,j;

        int g = bnum1.Length - 1;
        

        for (m = 0; m < bnum1.Length; m++)
         {
             
             j = Random.Range(1,g);
            
              

             rowcheker = bnum1[m];
             bnum1[m] = bnum1[j];
             bnum1[j] = rowcheker;
        }

        
        for (m = 0; m < 10; m++)
        {
            index[m] = bnum1[m];
            

        }

    }
         
    

}
