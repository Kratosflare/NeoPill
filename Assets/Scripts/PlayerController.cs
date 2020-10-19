using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   float horizontalInput;
   float verticalInput;
    private new Rigidbody rigidbody;
   float speed = 5.0f;
    float force = 4;
    bool isOnGround;
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);


        if(Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            rigidbody.AddForce(Vector3.up * force,ForceMode.Impulse);
            isOnGround = false;
        }


        
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
