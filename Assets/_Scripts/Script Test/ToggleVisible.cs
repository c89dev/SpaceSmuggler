using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToggleVisible : MonoBehaviour
{
    void Start()
    {

    }

    public bool boostActive = false;
    public GameObject JetUp;
    
    void Update()
    {
        if (boostActive)
        {
            Debug.Log("BOOSTING");
        }
        else


    // Space Hold
    if (Input.GetKey(KeyCode.Space))
    {
        boostActive = true;
    }
    
    // Space Up
    if (Input.GetKeyUp(KeyCode.Space))
    {
        boostActive = false;
    }
    
    // W Hold
    if (Input.GetKey(KeyCode.W) && boostActive == true)
    {
        var ps = JetUp.GetComponent<ParticleSystem>();
        if (!ps.isPlaying)
        {
            ps.Play();
        }
        Debug.Log("Jet Play");
    }
    
    // W Up
    if (Input.GetKeyUp(KeyCode.W) || boostActive == false)
    {
            JetUp.GetComponent<ParticleSystem>().Stop();
    }

        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     if (boostActive == false)
        //     {
        //         JetUp.GetComponent(typeof(ParticleSystem));
        //         {
        //             GetComponent<Renderer>().enabled = true;
        //         }
        //     }
        // }
        
        // if (Input.GetKeyUp(KeyCode.W))
        // {
        //     if (boostActive == false)
        //     {
        //         JetUp.GetComponent(typeof(ParticleSystem));
        //         {
        //             GetComponent<Renderer>().enabled = false;
        //         }
        //     }
        // }


        
    }
}
