using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeSwitshVideos : MonoBehaviour
{
    public GameObject V1;
    public GameObject V2;
    public GameObject V3;
    public string SceneName;

    public GameObject SkipBtn;

    public GameObject loadingScren;
    public Slider slider;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(V1toV2());
    }


    IEnumerator V1toV2()
    {
        yield return new WaitForSeconds(3f);
        V1.SetActive(false);
        V2.SetActive(true);
    }



    public IEnumerator V2toV3()
    {
        V2.SetActive(false);
        V3.SetActive(true);
        yield return new WaitForSeconds(50f);
        V3.SetActive(false);
        loedLevel();

    }

    public void GoToV3()
    {
        StartCoroutine(V2toV3());
    }



    IEnumerator WaitForLoading()
    {
        V3.SetActive(false);
        loadingScren.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(LoadTime());
    }

    public void loedLevel()
    {
               StartCoroutine(WaitForLoading());
    }
    IEnumerator LoadTime()
    {   
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);//debug from 0 to 0.9
        operation.allowSceneActivation = false;

        

        while (operation.isDone == false)
        {
            slider.value = operation.progress;

            if(operation.progress == 0.9f)//cause slider from 0 to 1
            {
                slider.value = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }


}
