using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody rb;
    InputScript inputScript;

    float moveSpeed = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputScript = GetComponent<InputScript>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inputScript.isUp == true)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, rb.velocity.z);
        }
        else if (inputScript.isDown == true)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);
        }
        else if (inputScript.isLeft == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -moveSpeed);
        }
        else if (inputScript.isRight == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.z, rb.velocity.y, rb.velocity.z);
        }
    }
}
