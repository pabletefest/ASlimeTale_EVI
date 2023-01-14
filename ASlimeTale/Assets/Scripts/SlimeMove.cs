using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    private CharacterController controller;
    public float playerSpeed;
    private Animator anim;
    private Vector3 vel;
    public GameObject camera;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 rightCamera = camera.transform.right;
        Vector3 forwardCamera = camera.transform.forward;

        Vector3 movementDirection = rightCamera * horizontalInput + forwardCamera * verticalInput;
        movementDirection += Physics.gravity;

        movementDirection.Normalize();

        vel = movementDirection * playerSpeed * Time.deltaTime;
        controller.Move(vel);

        if (movementDirection.x != 0 || movementDirection.z != 0)
        {
            movementDirection.y = 0;
            transform.forward = movementDirection;       
        }

        if(vel.x != 0 || vel.z != 0)
		{
            anim.SetBool("moving", true);
		} else
		{
            anim.SetBool("moving", false);
		}
    }
}
