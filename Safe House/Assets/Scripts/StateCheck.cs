using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateCheck : MonoBehaviour
{
    public Text titleText;

    // Start is called before the first frame update
    void Start()
    {
        int state = PlayerPrefs.GetInt("Game State");

        if(state == 1)
        {
            titleText.text = "You Won!";
        }
        else
        {
            titleText.text = "You Lost!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
