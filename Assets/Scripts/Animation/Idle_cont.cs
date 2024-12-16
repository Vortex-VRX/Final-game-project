using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_cont : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Example: Trigger the second idle after 5 seconds
        if (Time.time > 5f)
        {
            animator.SetBool("GoToIdle2", true);
        }
    }
}
