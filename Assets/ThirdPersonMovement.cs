using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    pubic float speed = 6f;
    void Update () {
       float hoizontal = Input.GetAxisRaw("Horizontal");
       float vertical = Input.GetAxisRaw("Vertical");
       Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;
    }
}
