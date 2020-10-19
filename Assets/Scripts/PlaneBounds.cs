﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    // detect the player
    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Player"))
        {
            Debug.Log("PLayer entered the fray");
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("You just died");
        }

    }
}
