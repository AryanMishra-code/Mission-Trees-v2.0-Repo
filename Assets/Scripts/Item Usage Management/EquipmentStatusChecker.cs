using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentStatusChecker : MonoBehaviour
{
    [SerializeField] private Text statusCheck;

    [Header("Item Usage Component")]
    [SerializeField] private ItemsUsageManagement _itemsUsageManagement;
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Plant Sapling")
        {
            _itemsUsageManagement.hasEquippedPlant = true;
            statusCheck.text = "EQUIPPED";
            statusCheck.color = Color.green;
            Destroy(gameObject);
        }
    }
}