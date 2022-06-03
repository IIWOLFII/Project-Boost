using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    [SerializeField]Vector3 desiredpos;
    [SerializeField] [Range(0,1)] float posfactor;    
    [SerializeField] float period;
    Vector3 startpos;

    void Start()
    {
        startpos = transform.position;
    }

    void Update()
    {   
        if (period <= Mathf.Epsilon){return;}
        float cycles = Time.time / period;  //+1 every period

        const float tau = Mathf.PI * 2; //6.283185
        float sinwave = Mathf.Sin(tau*cycles); //goes from -1 + 1 every 1 cycle
        posfactor = (sinwave+1)/2; // recalculated to go up and divided by 2 to not be 0 - 2


        Vector3 offset = desiredpos*posfactor;
        transform.position = startpos+offset;
        
    }
}
