using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int amount = 30;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject); //Bierze komponent zmienn� amount z funkcji GiveHealth ze skryptu PlayerHealth
            //Destroy(gameObject); //niszczy skrzynk� ale to damy do GiveHealth �eby nie niszczy�o jej jak mamy > 100hp
        }
    }
}
