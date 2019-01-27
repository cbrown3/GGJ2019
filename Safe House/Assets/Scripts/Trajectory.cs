using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private GameObject car;
    private float homingSensitivity = 0.5f;
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posDiff = car.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(posDiff);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, homingSensitivity);

        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}
