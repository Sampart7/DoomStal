using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public Material aggro;
    public float awerenessRadius = 7; //odleg�o�� zasi�gu wzroku przeciwnika
    public bool isAggro;
    private Transform playerTransform;
    public bool IsAvailable = true;

    public Animator enemyAttack;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform; //ustalenie gdzie jest gracz
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position); //ustalenie odleg�o�ci przeciwnika od gracza

        if(dist < awerenessRadius) //je�li odleglosc mniejsza od wzorku to zaczyna gonic
        {
            isAggro = true;
            GetComponent<MeshRenderer>().material = aggro; //zmienia kolor
        }

        if (dist < 2f && IsAvailable)
        {
            DealDamage();
            StartCoroutine(StartCooldown());
            enemyAttack.SetBool("isAttacking", true);
        }
    }

    private void DealDamage()
    {
        playerTransform.GetComponent<PlayerHealth>().DamagePlayer(30); //zadawanie dmg kiedy jest sie za blisko
    }

    public IEnumerator StartCooldown() //Cooldown
    {
        IsAvailable = false;
        yield return new WaitForSeconds(2); //czeka tyle ile podamy
        IsAvailable = true;
    }
}