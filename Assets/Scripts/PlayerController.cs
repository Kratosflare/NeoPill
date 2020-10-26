using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject holster;

    float horizontalInput;
   float verticalInput;

    new Rigidbody rigidbody;
   float speed = 5.0f;
    float force = 6;
    bool isOnGround;
    float deadZone = 0;
    Vector3 startPosition;
    Vector3 playerPosition;
    Vector2 lookDirection;
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rigidPosition = rigidbody.position;
        startPosition = new Vector3(15,2);
        playerPosition = new Vector3(transform.position.x, transform.position.y);
        Vector3 move = new Vector3(horizontalInput, verticalInput);


        //Player Movement

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        // holster in line with the player movement
        holster.transform.position = transform.position;


        //Player Jumping
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround)
        {
            rigidbody.AddForce(Vector3.up * force,ForceMode.Impulse);
            isOnGround = false;
        }
        //Respawn Mechanic if the player falls off the platform
        if(transform.position.y < deadZone)
        {
            transform.position = startPosition;
        }
        // If they press P they can shoot
        if (Input.GetKeyDown(KeyCode.P))
        {
            Shoot();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
    private void Shoot()
    {
            Instantiate(bullet, holster.transform.position, transform.rotation);
    }
}
