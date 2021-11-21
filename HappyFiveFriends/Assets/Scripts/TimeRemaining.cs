using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRemaining : MonoBehaviour
{
    public float timeRemaining = 30;
    public TMPro.TextMeshProUGUI remainingTime;
    public bool timeIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning) {

            if(timeRemaining > 0) {
                remainingTime.text = "Time Remaining: " + Mathf.FloorToInt(timeRemaining % 60);
                timeRemaining = timeRemaining - Time.deltaTime;
            }
        }
        else {
            timeIsRunning = false;
        }
    }
}
