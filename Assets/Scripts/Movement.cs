using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //parameters
    [SerializeField] float ms = 400f;
    [SerializeField] float rotates = 1f;
    [SerializeField] ParticleSystem thrus;
    [SerializeField] ParticleSystem sidethrusl;
    [SerializeField] ParticleSystem sidethrusr;

    //cache
    Rigidbody RBody;
    AudioSource Audio;

    //state
    //bool IsAlive = true;

    void Start() 
    {
        //ms = ms * Time.deltaTime;
        RBody = GetComponent<Rigidbody>();   
        Audio = GetComponent<AudioSource>();
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
            FlyForward();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
                Audio.Stop();
                thrus.Stop();
        }
    }

    void ProcessTilt()
    {
        FlyRotate();
    }


    void Rotate(float direction)
    {
        FlyRotate(direction);
    }

    void FlyForward()
    {
        RocketNoise();
        RBody.AddRelativeForce(0, ms * Time.deltaTime, 0);
        thrus.Play();
        if (!Audio.isPlaying)
        {
            Audio.Play();
        }
    }
    void FlyRotate()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Audio.Stop();
            sidethrusl.Stop();
            sidethrusr.Stop();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sidethrusl.Play();
            Rotate(rotates);
            RocketNoise();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            sidethrusr.Play();
            Rotate(-rotates);
            RocketNoise();
        }
    }
    void FlyRotate(float direction)
    {
        RBody.AddRelativeTorque(0, 0, direction * Time.deltaTime);
    }

    void RocketNoise()
    {
        if (!Audio.isPlaying)
        {
            Audio.Play();
        }
    }
}
