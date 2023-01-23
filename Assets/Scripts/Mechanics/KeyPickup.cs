using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool isKey1, isKey2, isKey3, isKey4, isKey5, isKey6;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(isKey1)
            {
                other.GetComponent<PlayerInventory>().Key1 = true; //je�li podniesiemy to do ekwipunku dostajemy key1 
            }
            if (isKey2)
            {
                other.GetComponent<PlayerInventory>().Key2 = true;
            }
            if (isKey3)
            {
                other.GetComponent<PlayerInventory>().Key3 = true;
            }
            if (isKey3)
            {
                other.GetComponent<PlayerInventory>().Key3 = true;
            }
            if (isKey4)
            {
                other.GetComponent<PlayerInventory>().Key4 = true;
            }
            if (isKey5)
            {
                other.GetComponent<PlayerInventory>().Key5 = true;
            }
            if (isKey6)
            {
                other.GetComponent<PlayerInventory>().Key6 = true;
            }
            Destroy(gameObject);
        }
    }
}
