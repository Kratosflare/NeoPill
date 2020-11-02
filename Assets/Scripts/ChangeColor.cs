using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private Material blasted;

    // Start is called before the first frame update
    void Start()
    {
       // blasted = GetComponent<Material>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            blasted.color = Color.white;

            Destroy(other.gameObject);

        }
    }
}
