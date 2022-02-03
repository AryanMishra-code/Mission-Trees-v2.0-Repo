using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentStatusChecker : MonoBehaviour
{
    [SerializeField] private Text statusCheckSapling;
    [SerializeField] private Text statusCheckBucket;
    [SerializeField] private Text statusCheckFence;

    [Header("Item Usage Component")]
    [SerializeField] private ItemsUsageManagement _itemsUsageManagement;
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Plant Sapling")
        {
            _itemsUsageManagement.hasEquippedPlant = true;
            statusCheckSapling.text = "EQUIPPED";
            statusCheckSapling.color = Color.green;
            Destroy(gameObject);
        }
        else if (gameObject.tag == "Bucket")
        {
            _itemsUsageManagement.hasEquippedBucket = true;
            statusCheckBucket.text = "EQUIPPED";
            statusCheckBucket.color = Color.green;
            Destroy(gameObject);
        }
    }
}