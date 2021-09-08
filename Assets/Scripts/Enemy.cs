using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D StreetThug;
    //Limits the fire rate
    public Health player;
    public float shotRate = 2.0f;
    private float shotTimer = 0.0f;

    void Start()
    {

    }


    void Update()
    {
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().health -= 15;
            Debug.Log(collision.gameObject.GetComponent<Health>().health);
        }
    }
    
    private void Fire_rate()
    {
        if (player.GetComponent<Health>().health >= 0)
        {
            if (shotTimer <= 0f)
            {
                shoot();
                shotTimer = shotRate;
            }
            shotTimer -= Time.deltaTime;


        }
    }
    private void shoot()
    {

    }

}
