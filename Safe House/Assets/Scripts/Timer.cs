using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float minutes = 5;
    public float seconds = 0;
    public float miliseconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (miliseconds <= 0)
        {
            if (seconds <= 0)
            {
                minutes--;
                seconds = 59;
            }
            else if (seconds >= 0)
            {
                seconds--;
            }

            miliseconds = 100;
        }

        miliseconds -= Time.deltaTime * 100;

        timer.text = string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds);
    }
}
