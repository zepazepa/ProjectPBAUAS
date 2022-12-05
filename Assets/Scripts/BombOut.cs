using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BombOut : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform SpawnPoint;
    Vector3 targetPos;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPos = hit.point;
                GameObject ball = Instantiate(ProjectilePrefab, SpawnPoint.transform.position, SpawnPoint.rotation);
                rb = ball.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward + targetPos, ForceMode.VelocityChange);
                rb.AddForce(transform.up + targetPos, ForceMode.VelocityChange);
            }
        }
    }

    private void FixedUpdate()
    {

       
    }


}

