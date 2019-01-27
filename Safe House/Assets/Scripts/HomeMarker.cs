using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMarker : MonoBehaviour
{
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("You won");

            camera.GetComponent<Timer>().setStart(false);
        }
    }
}
