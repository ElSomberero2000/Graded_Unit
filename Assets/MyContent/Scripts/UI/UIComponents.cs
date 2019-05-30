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
        startTime = Time.time; // Timer starts to count when the scene is loaded in 
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer();
    }

    private void CountdownTimer() // As the timer accumulates the time since start is removed from a set time for the game to be completed in (5 minutes)
    {
        float t = Time.time - startTime;

        string minutes = (4 - ((int)t / 60)).ToString();
        string seconds = (60 - (t % 60)).ToString("f0"); // f2 defines that only 2 decimals are in float when written to screen

        timerText.text = minutes + ":" + seconds; // WHat is written to the screen in the inventory
    }
}
