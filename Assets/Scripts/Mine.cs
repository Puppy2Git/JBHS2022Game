using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private int damage = 25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            // Collision with Player
            case ("Player"):
                collision.gameObject.GetComponent<Health>().health -= damage;
                Destroy(gameObject);
                break;
            // Collision with Bullet
            case ("Bullet"):
                Destroy(gameObject);
                break;
        }
    }

}