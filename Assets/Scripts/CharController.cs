using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController : MonoBehaviour
{
    private Animator animator;
    public float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Adjust speed based on input (e.g., move with arrow keys)
        speed = Input.GetAxis("Vertical");

        // Set the Speed parameter in the Animator
        animator.SetFloat("Speed", speed);
    }
}

