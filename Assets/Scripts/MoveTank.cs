using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    float speed = 5f;
    float acceleration = 0.5f;
    Vector3 accel = new Vector3(0f, 0f, 0.5f);
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (acceleration > 10f)
        {
            acceleration = 10f;
        }
        else
        {
            acceleration += acceleration * Time.deltaTime;
        }

        rb.MovePosition(rb.position + transform.forward * (speed + acceleration) * Time.deltaTime);
    }
}
