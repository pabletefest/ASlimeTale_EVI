using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPausa;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private AudioSource music;

    [SerializeField]
    private GameObject cameraSpin;

    private bool menuShown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuShown)
            {
                Time.timeScale = 0;
                menuPausa.SetActive(true);
                panel.SetActive(true);
                menuShown = true;
                cameraSpin.SetActive(false);
                music.Pause();
            }
            else
            {
                Time.timeScale = 1;
                menuPausa.SetActive(false);
                panel.SetActive(false);
                menuShown = false;
                cameraSpin.SetActive(false);
                music.Play();
            }
        }
    }
}
