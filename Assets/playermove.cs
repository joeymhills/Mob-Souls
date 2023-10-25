using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float forwardforce = 1000f;
    public float sideforce = 1000f;
    public Rigidbody rb;

    void FixedUpdate () {
        rb.AddForce(0,0, 0 * Time.deltaTime);

        if (Input.GetKey("d")) {
            rb.AddForce(sideforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(forwardforce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-forwardforce * Time.deltaTime, 0, 0);
        }
    }


}
