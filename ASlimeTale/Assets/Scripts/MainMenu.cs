using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartGame();
        }
    }

    public void StartGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("LlanuraAfable");
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
