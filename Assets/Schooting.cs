using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schooting : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb.useGravity = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Crash!\n");
        Destroy(gameObject);
    }
}
