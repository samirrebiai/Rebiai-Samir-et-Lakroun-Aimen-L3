using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class CharacterSelection : MonoBehaviour
{
	public GameObject[] characters;
	public int selectedCharacter = 0;


    private void Start()
    {

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;


	}


	public void NextCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter = (selectedCharacter + 1) % characters.Length;
		characters[selectedCharacter].SetActive(true);
		
	}

	public void PreviousCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += characters.Length;
		}
		characters[selectedCharacter].SetActive(true);
	}

	public void StartGame()
	{

        switch (selectedCharacter)
        {
			case 0: SceneManager.LoadScene("gArticle");break;
			case 1: SceneManager.LoadScene("Museum");break;
			case 2: SceneManager.LoadScene("Quiz");break;
		}

	}
}
