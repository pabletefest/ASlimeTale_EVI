using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamaraChangeCredits : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject desiredPosition;
    [SerializeField]
    private GameObject camera;
    public float desiredTime;
    private bool mouse_over = false;
    public Sprite normalSprite;
    public Sprite hoverSprite;
    private Button pb;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        pb = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouse_over)
        {
            if (time < desiredTime)
            {
                time += Time.deltaTime;
            }
            //camera.transform.position = Vector3.MoveTowards(camera.transform.position, desiredPosition.transform.position, Speed * Time.deltaTime);
            camera.transform.position = Vector3.Lerp(camera.transform.position, desiredPosition.transform.position, time / desiredTime);
            camera.transform.eulerAngles = new Vector3(-0.136f, 250.955f, 0f);
        }
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        mouse_over = true;
        pb.image.sprite = hoverSprite;
        //Output to console the GameObject's name and the following message
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        pb.image.sprite = normalSprite;
        mouse_over = false;
        time = 0;
    }
}