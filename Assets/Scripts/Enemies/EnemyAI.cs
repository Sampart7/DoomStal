using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness; //referencje 
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent enemyNavMeshAgent; //tu jaka� pojebana bo z pakietu AI ale tak to nic si� nie zmienia

    void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        enemyNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(enemyAwareness.isAggro) //jesli �apie agro
        {
            enemyNavMeshAgent.SetDestination(playerTransform.position); //idzie do gracza
        }
    }
}
