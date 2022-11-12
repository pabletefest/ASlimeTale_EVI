using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Monster":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Reclutar");
                break;

            case "Enemy":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Combat");
                break;

            default:
                break;
        }

    }
}
