using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    public Slider slider;
    private Transform y_val;

    // Start is called before the first frame update
    void Start()
    {
        y_val = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        restart(health);
        SetHealth(health);
        into_void(y_val.position.y);

    }

    public void SetHealth(int health) {
        slider.value = health;
    }

    public void setMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void restart(int health) {
        if(health <= 0)
        {
            restart();
        }
    }
    public void into_void(float height)
    {
        if(height <= -15)
        {
            restart();
        }

    }
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
        setMaxHealth(100);
    }
}
