using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFX : MonoBehaviour
{
    public GameObject treeFX;
    public GameObject propFX;
    public GameObject buildingFX;
    public GameObject missileFX;
    public GameObject carFX;
    public GameObject npcFX;
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
        GameObject other = collision.gameObject;
        if (other.tag == "Building")
        {
            Debug.Log("You hit a building");
            Instantiate(buildingFX, transform.position, Quaternion.identity);
        }
        if (other.tag == "Missile")
        {
            Instantiate(missileFX, transform.position, Quaternion.identity);
        }
        if (other.tag == "NPC")
        {
            Debug.Log("You hit an NPC");
            Instantiate(npcFX, transform.position, Quaternion.identity);
        }
        if (other.tag == "Tree")
        {
            Debug.Log("You hit a tree");
            Instantiate(treeFX, transform.position, Quaternion.identity);
        }
        if (other.tag == "Prop")
        {
            Debug.Log("You hit a prop");
            Instantiate(propFX, transform.position, Quaternion.identity);
        }
        if (other.tag == "Car")
        {
            Debug.Log("You hit a car");
            Instantiate(carFX, transform.position, Quaternion.identity);
        }
    }
}
