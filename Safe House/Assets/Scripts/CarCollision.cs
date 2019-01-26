using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Building")
        {
            Debug.Log("You hit a building");
        }
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("You hit an NPC");
        }
        if (collision.gameObject.tag == "Tree")
        {
            collision.gameObject.GetComponent<Rigidbody>();
        }
        if (collision.gameObject.tag == "Car")
        {
            Debug.Log("You hit a car");
        }
    }
}
