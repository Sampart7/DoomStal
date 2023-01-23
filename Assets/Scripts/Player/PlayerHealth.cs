using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        SetHealth();
    }

    public void DamagePlayer(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("KONIEC");
            Scene currentScene = SceneManager.GetActiveScene(); //Tworzenie scenki w silniku Unity
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    public void GiveHealth(float amount, GameObject pickup)
    {
        if(health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }
        else
        {
            health = maxHealth;
        }
    }

    public void SetHealth()
    {
        slider.value = health;
    }

}