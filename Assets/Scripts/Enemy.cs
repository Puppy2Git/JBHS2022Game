using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D StreetThug;
    public Health player;
    //Fire Rate
    public float shotRate = 2.0f;
    private float shotTimer = 0.0f;
    //Enemys Health
    private int current_health = 100;

    void Start()
    {

    }


    void Update()
    {
        check_enemy_health();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) {
            case ("Player"):
                collision.gameObject.GetComponent<Health>().health -= 15;
                Debug.Log(collision.gameObject.GetComponent<Health>().health);
                break;

            case ("Bullet"):
                current_health -= 100;
                break;
            

        }

    }
    private void check_enemy_health()
    {
        if(current_health <= 0)
        {
            Destroy(gameObject);
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
