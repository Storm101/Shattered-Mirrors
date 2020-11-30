using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerChange : MonoBehaviour
{
    public GameObject floor;

    public Transform hiddenCheck;
    public float hiddenDistance = 0.2f;
    public LayerMask hiddenMask;
    public LayerMask groundMask;
    bool isHidden;
    bool isGrounded;

    void Update()
    {
        isHidden = Physics.CheckSphere(hiddenCheck.position, hiddenDistance, hiddenMask);
        isGrounded = Physics.CheckSphere(hiddenCheck.position, hiddenDistance, groundMask);

        if (floor == null)
        {
            return;
        }

        if (isHidden)
        {
            floor.layer = 0;
        }
        if (isGrounded)
        {
            floor.layer = 10;
        }
    }
}
