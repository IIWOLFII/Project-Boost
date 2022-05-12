using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float ms = 400f;
    [SerializeField] float rotates = 1f;
    Rigidbody RBody;

    void Start() 
    {
        //ms = ms * Time.deltaTime;
        RBody = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        ProcessSpeed();
        ProcessTilt();
    }

    void ProcessSpeed()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RBody.AddRelativeForce(0,ms*Time.deltaTime,0);
        }
    }

        void ProcessTilt()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(rotates);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(-rotates);
        }
    }

    void Rotate(float dir)
    {
        RBody.AddRelativeTorque(0, 0, dir);
    }
}
