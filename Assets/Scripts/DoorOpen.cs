using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;

    bool timerStarted = false;

    public Animator leftDoorAnim;
    public Animator rightDoorAnim;

    void Start()
    {
        rightDoorAnim.SetBool("RightDoorOpen", false);
        leftDoorAnim.SetBool("LeftDoorOpen", false);
    }

    void Update()
    {
        if (timerStarted)
        {
            _timer += Time.deltaTime;
            if (_timer >= TimeIWant)
            {
                _timer = 0f;
                timerStarted = false;
                rightDoorAnim.SetBool("RightDoorOpen", false);
                leftDoorAnim.SetBool("LeftDoorOpen", false);
            }
        }
    }

    public float _timer = 0f;
    public float TimeIWant = 2f;

    void OnTriggerStay(Collider door)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rightDoorAnim.SetBool("RightDoorOpen", true);
            leftDoorAnim.SetBool("LeftDoorOpen", true);
            if (!timerStarted)
            {
                timerStarted = true;
            }
        }
    }
}
