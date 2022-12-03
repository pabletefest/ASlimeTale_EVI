using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Return))
		{
            UnityEngine.SceneManagement.SceneManager.LoadScene("LlanuraAfable");
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LlanuraAfable");
    }

    public void ShowCredits()
	{
        mainMenu.SetActive(false);
        credits.SetActive(true);
	}

    public void ReturnToMenu()
	{
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void ExitGame()
	{
        Application.Quit();
    }
}
