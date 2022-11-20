using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody rb;
    public int bulletDamage = 0;
    public int speed = 0;
    public int size = 0;

    public float bulletLive = 3f;

    void Start()
    {
        rb.useGravity = false;
        //bulletDamage = 5;
    }

    // Update is called once per frame
    private void Update()
    {
        if (bulletLive <= 0) Destroy(gameObject);
        bulletLive -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Crash!\n");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Start();
    }
}
