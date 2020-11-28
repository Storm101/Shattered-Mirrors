using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerThoughtDialogue : MonoBehaviour
{
    public string text;
    public GameObject triggerText;

    public float time;
    public float timeIWant;
    public bool timerActive;


    void Start()
    {
        triggerText = GameObject.Find(text);
        timeIWant = 2;
    }

    void OnTriggerEnter(Collider innerThought)
    {
        triggerText.SetActive(true);

        timerActive = true;
        timer();
    }

    void timer()
    {
        if (timerActive)
            time = Time.deltaTime;
        if (time >= timeIWant)
        {
            timerActive = false;
            time = 0;
        }
    }
}
