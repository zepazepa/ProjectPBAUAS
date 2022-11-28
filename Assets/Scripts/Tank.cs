using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tank : MonoBehaviour
{
    // Start is called before the first frame update

    //kebutuhan: tank bisa gerak dengan wasd tanpa transform.position
    //public Vector3 limitAccel;
    float speed = 5f;
    float acceleration = 0.5f;
    Vector3 accel = new Vector3(0f, 0f, 0.5f);
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
        //maju - mundur
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (acceleration > 10f)
            {
                acceleration = 10f;
            }
            else
            {
                acceleration += acceleration * Time.deltaTime;
            }
            //rb.MovePosition((Vector3.right * (speed + acceleration) * Time.deltaTime * Mathf.Sin(rb.rotation.y * Mathf.Deg2Rad)) // itung maju lurus
            //    + (Vector3.forward * (speed + acceleration) * Time.deltaTime * Mathf.Cos(rb.rotation.y * Mathf.Deg2Rad)) 
            //    + rb.position);//maju agak belok 

            //rb.MovePosition(new Vector3(rb.position.x + ((speed + acceleration) * Time.deltaTime * Mathf.Sin(rb.rotation.y *Mathf.Rad2Deg)),rb.position.y,
            //    rb.position.z +((speed + acceleration) * Time.deltaTime * Mathf.Cos(rb.rotation.y *Mathf.Rad2Deg))));

            rb.MovePosition(rb.position + transform.forward * (speed + acceleration) * Time.deltaTime); //bisa gerak ke arah tank
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (acceleration > 5f)
            {
                acceleration = 5f;
            }
            else
            {
                acceleration += acceleration * Time.deltaTime;
            }
            //rb.MovePosition((Vector3.left * (speed + acceleration) * Time.deltaTime) + rb.position);
            rb.MovePosition(rb.position - transform.forward * (speed + acceleration) * Time.deltaTime); //bisa gerak ke arah tank
        }
        else if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            acceleration = 0.5f;
        }

        //kanan-kiri
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            //rb.MovePosition((Vector3.back * speed * Time.deltaTime) + rb.position);
            Quaternion angle = Quaternion.Euler(new Vector3(0f,25f,0f) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * angle);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.MovePosition((Vector3.forward * speed * Time.deltaTime) + rb.position);
            rb.MoveRotation(Quaternion.Euler(rb.rotation.eulerAngles - new Vector3(0f, 0.5f, 0f)));
        }
        
    }
}
