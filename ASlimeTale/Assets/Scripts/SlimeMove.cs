using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = 5.0f;
    private float turnSpeed = 90.0f;
    private Animator anim;
    private Vector3 vel;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        vel = transform.forward * Input.GetAxis("Vertical") * playerSpeed;
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
