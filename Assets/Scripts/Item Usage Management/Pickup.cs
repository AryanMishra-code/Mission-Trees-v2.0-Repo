using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject equippedPrefab = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ItemUser>().PickupItem(equippedPrefab);
            Destroy(gameObject);
        }
    }
}
