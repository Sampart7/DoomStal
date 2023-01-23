using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMenager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>(); //lista zaznaczonych przeciwnikow

    public void AddEnemy(Enemy enemy) //dodajemy do listy
    {
        enemiesInTrigger.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy) //uwuwamy z listy
    {
        enemiesInTrigger.Remove(enemy);
    }

}
