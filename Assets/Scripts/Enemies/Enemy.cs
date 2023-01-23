using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyMenager enemyMenager;
    public GameObject hitEffect;
    public float enemyHealth = 4;

    public PlayerSword dmg;
    public PlayerMovement mvm;
    void Update()
    {
        if (enemyHealth <= 0) //jeœli hp mniejsze od zera
        {
            enemyMenager.RemoveEnemy(this); //usuwa z listy
            Destroy(gameObject); //usuwa obiekt z unity
            dmg.SetDamage(1);
            mvm.SetSpeed(1);
        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity); //efekt i jego pozycja
        enemyHealth -= damage; //hp siê zmniejsza
    }
}
