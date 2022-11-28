using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tank : MonoBehaviour
{
    // Start is called before the first frame update

    //kebutuhan: tank bisa gerak dengan wasd tanpa transform.position
    //public Vector3 limitAccel;
    float speed = 10f;
    Rigidbody rb;
    //tank bisa rotate
    //tank memiliki akselerasi dan maksimum nilai akselerasi dibatasi
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition((Vector3.right * speed * Time.deltaTime) + rb.position);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition((Vector3.left * speed * Time.deltaTime) + rb.position);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition((Vector3.back * speed * Time.deltaTime ) + rb.position);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition((Vector3.forward * speed * Time.deltaTime) + rb.position);
        }
    }
}
