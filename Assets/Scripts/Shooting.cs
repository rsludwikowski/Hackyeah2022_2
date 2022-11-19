using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody rb;
    public int bulletDamage = 0;
    public int speed = 0;
    public int size = 0;

    void Start()
    {
        rb.useGravity = false;
        //bulletDamage = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Crash!\n");
        //Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Start();
    }
}
