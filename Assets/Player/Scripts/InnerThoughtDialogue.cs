using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InnerThoughtDialogue : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI text;

    public GameObject trigger;

    public float time;
    public float timeIWant;
    public bool timerActive;

    void Start()
    {
        time = 0;
        timeIWant = 2;
        panel.enabled = false;
        text.enabled = false;
        timerActive = false;
    }
    void OnTriggerEnter(Collider innerThought)
    {
        panel.enabled = true;
        text.enabled = true;

        timerActive = true;
    }
    void Update()
    {
        if (timerActive)
            time += Time.deltaTime;
        if (time >= timeIWant)
        {
            timerActive = false;
            time = 0;
            panel.enabled = false;
            text.enabled = false;
            Destroy(trigger);
        }
    }
}
