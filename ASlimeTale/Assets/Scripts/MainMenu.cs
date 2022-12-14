using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject credits;
    public GameObject settings;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
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

    public void ShowSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void ReturnToMenu()
	{
        mainMenu.SetActive(true);
        credits.SetActive(false);
        settings.SetActive(false);
    }

    public void ExitGame()
	{
        Application.Quit();
    }
}
