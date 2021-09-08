using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        restart(health);
        SetHealth(health);

    }

    public void SetHealth(int health) {
        slider.value = health;
    }

    public void setMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void restart(int health) {
        if(health <= 0) {
            SceneManager.LoadScene("SampleScene");
            setMaxHealth(100);
        }
    }



}
