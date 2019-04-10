using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
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
        Countdown();
    }

    private void Countdown()
    {
        float t = Time.time - startTime;

        string minutes = (4 - ((int)t / 60)).ToString();
        string seconds = (60 - (t % 60)).ToString("f0"); // f2 defines that only 2 decimals are in float

        timerText.text = minutes + ":" + seconds;
    }
}
