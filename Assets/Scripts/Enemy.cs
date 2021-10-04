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
    public BulletScript bullet;
    public Transform Crosshair;


    // Var
    public int damage = 15;
    public float shotRate = 2.0f;
    private float shotTimer = 0.0f;
    private int enemy_health = 100;
    private float movement_speed = 5f;
    public float bulletSpeed = 25;
    public float offset;
    public bool do_shoot;
    public float rotationOffset = 90f;
    private float time = 5f;
    private float time_one = 30f;
    private bool stim_state;
    private float randomNumber;
    private bool isRanged;

    void Start()
    {
        StreetThug = gameObject.GetComponent<Rigidbody2D>();
        Player = player.GetComponent<Transform>();
        attack_type();
    }


    void Update()
    {
        Enemy_Movement();
        Enemy_Death(enemy_health);
        Go_to_character(movement);
        Stim_Timer();

    }

    private void attack_type()
    {
        randomNumber = Random.Range(0, 2);
        if (randomNumber == 1)
        {
            isRanged = true;
            enemy_type(isRanged);
        }
        else
        {
            isRanged = false;
            enemy_type(isRanged);
        }


    }
    private void enemy_type(bool attack_type)
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            // Collision with Player
            case ("Player"):
                collision.gameObject.GetComponent<Health>().health -= damage;
                Debug.Log(collision.gameObject.GetComponent<Health>().health);
                break;
            // Collision with Bullet
            case ("Bullet"):
                enemy_health -= 100;
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
    public void Stim_Timer()
    {
        if (player.GetComponent<Health>().health >= 0)
        {
            if (time_one <= 0)
            {
                damage = 20;
                movement_speed = 10;
                time_one = 30f;
                stim_state = true;

            }
            time_one -= Time.deltaTime;
            if (stim_state == true)
            {
                if (time <= 0)
                {
                    damage = 15;
                    movement_speed = 3;
                    stim_state = false;
                    time = 5f;
                }
                time -= Time.deltaTime;
            }
        }

    }
    // Enemy Fire rate
    private void Fire_rate()
    {
        if (player.GetComponent<Health>().health >= 0)
        {
            if (shotTimer <= 0f)
            {
                Enemy_shoot();
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
        if (direction.x >= transform.position.x)
        {
            StreetThug.GetComponent<SpriteRenderer>().flipY = true;
            direction.Normalize();
            movement = direction;
            Go_to_character(movement);
        }
        else if (direction.x <= transform.position.x)
        {
            StreetThug.GetComponent<SpriteRenderer>().flipY = false;
            direction.Normalize();
            movement = direction;
            Go_to_character(movement);

        }
    }
    private void Go_to_character(Vector2 direction)
    {
        StreetThug.MovePosition((Vector2)transform.position + (direction * movement_speed * Time.deltaTime));
    }
    // Making the enemy shoot
    private void Enemy_shoot()
    {
       
        

    }
}