using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Provisional press enter to recruit
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //TODO Add monster to team



            UnityEngine.SceneManagement.SceneManager.LoadScene("LlanuraAfable");
        }
    }
}
