using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public bool isUp;
    public bool isDown;
    public bool isLeft;
    public bool isRight;


    void Start()
    {
        
    }

 
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            isDown = true;
        }
        else
        {
            isDown = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
        
    }
}
