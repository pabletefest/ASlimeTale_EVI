using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoStartTimer : MonoBehaviour
{
    private const float runoverTime = 5f;
    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= runoverTime)
            SceneManager.LoadScene("LLanuraAfable");

        elapsedTime += Time.deltaTime;
    }
}
