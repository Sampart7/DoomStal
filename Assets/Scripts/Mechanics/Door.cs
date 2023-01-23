using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject areaToSpawn;

    public bool requiresKey;
    public bool rKey1, rKey2, rKey3, rKey4, rKey5, rKey6;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //kiedy gracz w nie wejdzie
        {
            if(requiresKey)
            {
                if(rKey1 && other.GetComponent<PlayerInventory>().Key1)
                {
                    doorAnim.SetTrigger("DoorOpened"); //otwieranie drzwi 
                    areaToSpawn.SetActive(true); //Po przej�ciu przez drzi respi� si� przeciwnicy (Unity jest �atwe)
                }
                if (rKey2 && other.GetComponent<PlayerInventory>().Key2)
                {
                    doorAnim.SetTrigger("DoorOpened");
                    areaToSpawn.SetActive(true);
                }
                if (rKey3 && other.GetComponent<PlayerInventory>().Key3)
                {
                    doorAnim.SetTrigger("DoorOpened");
                    areaToSpawn.SetActive(true);
                }
                if (rKey4 && other.GetComponent<PlayerInventory>().Key4)
                {
                    doorAnim.SetTrigger("DoorOpened");
                    areaToSpawn.SetActive(true);
                }
                if (rKey5 && other.GetComponent<PlayerInventory>().Key5)
                {
                    doorAnim.SetTrigger("DoorOpened");
                    areaToSpawn.SetActive(true);
                }
                if (rKey6 && other.GetComponent<PlayerInventory>().Key6)
                {
                    doorAnim.SetTrigger("DoorOpened");
                    areaToSpawn.SetActive(true);
                }
            }
            else
            {
                doorAnim.SetTrigger("DoorOpened");
                areaToSpawn.SetActive(true);
            }
        }
    }
}
