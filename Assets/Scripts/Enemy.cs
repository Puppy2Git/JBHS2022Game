using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Objects
    public GameObject player;
    private Transform Player;
    private Rigidbody2D StreetThug;
    private Vector2 movement;
    

    // Var
    public float shotRate = 2.0f;
    private float shotTimer = 0.0f;
    private int enemy_health = 100;
    private float movement_speed = 3f;
    

    void Start()
    {
        StreetThug = gameObject.GetComponent<Rigidbody2D>();
        Player = player.GetComponent<Transform>();
    }


    void Update()
    {
        Enemy_Movement();
        Enemy_Death(enemy_health);
        Go_to_character(movement);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            // Collision with Player
            case("Player"):
                collision.gameObject.GetComponent<Health>().health -= 15;
                Debug.Log(collision.gameObject.GetComponent<Health>().health);
                break;
            // Collision with Bullet
            case ("Bullet"):
                enemy_health -= 100;
                Debug.Log("Enemy died");
                break;
        }
    }
    // Enemy Death
    private void Enemy_Death(int health)
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
   
    // Enemy Fire rate
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

    //Enemy Movement

    private void Enemy_Movement()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        StreetThug.rotation = angle;
        direction.Normalize();
        movement = direction;

    }
    private void Go_to_character(Vector2 direction)
    {
        
        StreetThug.MovePosition((Vector2)transform.position + (direction * movement_speed * Time.deltaTime));
    }
    // Making the enemy shoot
    private void shoot()
    {

    }

}