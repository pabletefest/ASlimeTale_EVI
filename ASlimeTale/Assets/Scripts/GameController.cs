using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
