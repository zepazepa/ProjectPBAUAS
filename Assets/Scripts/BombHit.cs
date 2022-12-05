using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombHit : MonoBehaviour
{
    public Rigidbody tank, bomb;
    public Rigidbody ground;
    public HealthBar healthBar;
    public int health;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        tank = GetComponent<Rigidbody>();

        health = (int)healthBar.slider.maxValue; // get max health
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.health = health;
        if (health == 0)//do something
        {
            tank.AddRelativeForce(Vector3.up * 100000f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != ground)
        {
            bomb = collision.rigidbody;
            health -= damage;
            tank.AddExplosionForce(100f, Vector3.up, 5f);
        }

    }
}
