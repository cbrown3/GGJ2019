using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            camera.GetComponent<Timer>().setStart(false);

            PlayerPrefs.SetInt("Game State", 1);

            Debug.Log("You won");

            SceneManager.LoadScene(1);

        }
    }
}
