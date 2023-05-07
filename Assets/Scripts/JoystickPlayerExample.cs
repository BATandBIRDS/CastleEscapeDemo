using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    Animator animator;
    ItemCollection ic;
    public float speed = 5f;
    public float rotateSpeed = 5f;
    public FloatingJoystick floatingJoystick;

    void Start()
    {
        ic = GetComponent<ItemCollection>();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        if (direction != Vector3.zero)
        {
            animator.SetTrigger("isRunning");
            transform.position += direction * speed * Time.fixedDeltaTime;
        }
        else
        {
            animator.ResetTrigger("isRunning");
        }
    }

    void RotatePlayer()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (ic.hasBook && other.tag == "Enemy")
        {
            animator.ResetTrigger("isRunning");
            animator.SetTrigger("canAttack");
        }
    }
}