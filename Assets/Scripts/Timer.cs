using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 10.0f;
    public bool timerEnd = false;
    public Text startText;
    public PlayerController controller;
    public AudioClip collectedClip;
    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0){
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
        }

        if (timeLeft <= 0 && timerEnd == false && controller.win == false)
        {
            controller.PlaySound(collectedClip);
            timerEnd = true;
        }
    }
}
