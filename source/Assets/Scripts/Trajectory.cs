using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private GameObject car;
    private float homingSensitivity = 0.5f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(car.transform);

        transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}
