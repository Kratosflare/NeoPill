using System.Collections;
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
    private void OnCollisionEnter(Collision collision)
    {
        if(CompareTag("Player"))
        {
            Debug.Log("PLayer entered the fray");
        }
    }
}
