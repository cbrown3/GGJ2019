using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float minutes;
    public float seconds;
    public float milliseconds;
    public bool start = false;

    /** the time on the timer that will switch the color from green to yellow in minutes **/
    public int GreentoYellow;

    /** the time on the timer that will switch the color from yellow to red in seconds**/
    public float YellowtoRed;

    /** the time on the timer that will make the timer flash in seconds**/
    public float RedFlash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
        
            // game over
            if (milliseconds <= 0 && seconds <= 0 && minutes <= 0)
            {
                PlayerPrefs.SetInt("Game State", 0);

                SceneManager.LoadScene(1);
            }

            if (milliseconds <= 0)
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

                milliseconds = 100;
            }

            milliseconds -= Time.deltaTime * 100;

            string minuteStr = minutes.ToString();
            string secondStr = seconds.ToString();
            string millisecondStr = milliseconds.ToString();

            if (seconds < 10)
            {
                secondStr = "0" + secondStr;
            }

            if (milliseconds < 10)
            {
                millisecondStr = "0" + millisecondStr;
            }

            millisecondStr = millisecondStr.Substring(0, 2);

            timer.text = minuteStr + ":" + secondStr + ":" + millisecondStr;

            //Update the color

            if (minutes <= 0 && seconds < YellowtoRed)
            {
                timer.CrossFadeColor(Color.red, 0.1f, true, false);
                return;
            }
            else if (minutes < GreentoYellow)
            {
                timer.CrossFadeColor(Color.yellow, 0.1f, true, false);
                return;
            }
            else
            {
                timer.color = Color.green;
            }
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public void setStart(bool start)
    {
        this.start = start;
    }
}

