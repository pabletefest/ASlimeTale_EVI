using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private GameObject cameraSpin;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("bossDefeated", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("enemiesBeaten") >= 3)
        {
            boss.SetActive(true);
        }
        else
        {
            boss.SetActive(false);
        }
        if (PlayerPrefs.GetInt("bossDefeated") == 1)
        {
            boss.SetActive(false);
            cameraSpin.SetActive(false);
            credits.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            credits.SetActive(false);
        }

    }
}
