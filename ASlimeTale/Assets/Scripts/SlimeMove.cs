using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    private CharacterController controller;
    public float playerSpeed = 5.0f;
    public float turnSpeed = 90.0f;
    private Animator anim;
    private Vector3 vel;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(0, horizontalInput * turnSpeed * Time.deltaTime, 0);

        vel = transform.forward * verticalInput * playerSpeed;

        controller.SimpleMove(vel);

        if(vel != Vector3.zero)
		{
            anim.SetBool("moving", true);
		} else
		{
            anim.SetBool("moving", false);
		}
    }
}
