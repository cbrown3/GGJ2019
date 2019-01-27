using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notoriety : MonoBehaviour
{
    public GameObject policeChopper;
    public Object missilePrefab; 
    public float movementSpeed = 25;
    private bool pursuit;
    private bool missileFired;
    public Text notoriety;

    // Start is called before the first frame update
    void Start()
    {
        pursuit = false;
        missileFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pursuit)
        {
            Debug.Log("Cops are in pursuit!");

            policeChopper.transform.LookAt(gameObject.transform);
            Vector3 chopperPos = policeChopper.transform.position;
            chopperPos += -transform.forward * movementSpeed * Time.deltaTime;
            chopperPos = new Vector3(chopperPos.x, 33, chopperPos.z);
            policeChopper.transform.position = chopperPos;

            GameObject[] blockades = GameObject.FindGameObjectsWithTag("Blockade");

            foreach (GameObject obj in blockades)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, 0, obj.transform.position.z);
            }

            GameObject[] spikes  = GameObject.FindGameObjectsWithTag("Spikes");

            foreach (GameObject obj in spikes)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, 0.2f, obj.transform.position.z);
            }

            GameObject missile = null;

            if (!missileFired)
            {
                missile = (GameObject)Instantiate(missilePrefab, policeChopper.transform.position, /*Quaternion.LookRotation(gameObject.transform.forward)*/Quaternion.identity);

                missileFired = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.name.Contains("Street"))
        {
            pursuit = true;


            notoriety.text = "RUN. [MISSILES INCOMING]";
        }
    }

    public void setMissileFired(bool missileFired)
    {
        this.missileFired = missileFired;
    }
}
