using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPausa;

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
                menuShown = true;
            }
            else
            {
                Time.timeScale = 1;
                menuPausa.SetActive(false);
                menuShown = false;
            }
        }
    }
}
