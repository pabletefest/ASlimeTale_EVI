using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoStartTimer : MonoBehaviour
{
    private const float runoverTime = 5f;
    private float elapsedTime = 0f;
    private Vector3 lastMousePos;

    void Awake()
    {
        lastMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Input.mousePosition, lastMousePos) > 0.1)
        {
            elapsedTime = 0f;
            lastMousePos = Input.mousePosition;
        }

        if (elapsedTime >= runoverTime)
            SceneManager.LoadScene("LLanuraAfable");

        elapsedTime += Time.deltaTime;
    }
}
