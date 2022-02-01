using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSaplingContainer : MonoBehaviour
{
    [SerializeField] private Text statusCheck;
    
    private void OnTriggerEnter(Collider other)
    {
        statusCheck.text = "EQUIPPED";
        statusCheck.color = Color.green;
        Destroy(gameObject);
    }
}