using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, 1);
    }
    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
