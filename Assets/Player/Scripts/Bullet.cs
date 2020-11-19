using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 50f;
    
    
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
        Invoke("DestroySelf", 0.5f);
    }
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        DestroySelf();
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
