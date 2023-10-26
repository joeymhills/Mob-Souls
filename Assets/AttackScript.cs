using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Hashing to increase performance

    }
    void Update()
    {
        //Running animations
        bool isAttacking = animator.GetBool("isAttacking");

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", true);
        }
    }
    }
