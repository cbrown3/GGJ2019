using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notoriety : MonoBehaviour
{
    public GameObject policeChopper;
    public float movementSpeed = 25;
    private bool pursuit;
    public Text notoriety;

    // Start is called before the first frame update
    void Start()
    {
        pursuit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(pursuit)
        {
            Debug.Log("Cops are in pursuit!");

            policeChopper.transform.LookAt(gameObject.transform);
            Vector3 chopperPos = policeChopper.transform.position;
            chopperPos += -transform.forward * movementSpeed * Time.deltaTime;
            chopperPos = new Vector3(chopperPos.x, 33, chopperPos.z);
            policeChopper.transform.position = chopperPos;

            GameObject[] blockades = GameObject.FindGameObjectsWithTag("Blockade");

            foreach(GameObject obj in blockades)
            {
                obj.transform.position = new Vector3(obj.transform.position.x, 0, obj.transform.position.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.name.Contains("Street"))
        {
            pursuit = true;

            notoriety.text = "RUN.";
        }
    }
}
