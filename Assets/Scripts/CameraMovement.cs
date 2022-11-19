using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform toFollow;
    public Vector3 offset = new Vector3(0, 0, 0);
    public float lerpTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = toFollow.position + offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, toFollow.position + offset, lerpTime*Time.fixedDeltaTime);
    }
}