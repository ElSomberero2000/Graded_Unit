using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComponents : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();
    }

    private void CountdownTimer()
    {
        float t = Time.time - startTime;

        string minutes = (2 - ((int)t / 60)).ToString();
        string seconds = (10 - (t % 10)).ToString("f0"); // f2 defines that only 2 decimals are in float

        timerText.text = minutes + ":" + seconds;

        if ( seconds == "0")
        {
            seconds = ((10 - (t % 10))-1).ToString("f0");
        }
    }
}
