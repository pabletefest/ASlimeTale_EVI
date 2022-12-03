using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamaraChangeOptions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject desiredPosition;
    [SerializeField]
    private GameObject camera;
    public float desiredTime;
    private bool mouse_over = false;
    private Vector3 desiredRotation;
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
                float t = time / desiredTime;
                t = t * t * (3f - 2f * t);
                camera.transform.position = Vector3.Lerp(camera.transform.position, desiredPosition.transform.position, t);
                time += Time.unscaledDeltaTime;
            }
            else 
            {
                camera.transform.position = desiredPosition.transform.position;
            }
            //camera.transform.position = Vector3.MoveTowards(camera.transform.position, desiredPosition.transform.position, Speed * Time.deltaTime);
            //camera.transform.position = Vector3.Lerp(camera.transform.position, desiredPosition.transform.position, time / desiredTime);
            camera.transform.eulerAngles = new Vector3(-1.756f, 169.11f, 2.791f);
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
