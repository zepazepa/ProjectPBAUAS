using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Cannon : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") == true)
        {
            GameObject ball = Instantiate(ProjectilePrefab, SpawnPoint.transform.position, SpawnPoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.VelocityChange);
            rb.AddForce(transform.up * 10f, ForceMode.VelocityChange);

        }
    }
}

