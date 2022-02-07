using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Water;

public class WaterBucket : MonoBehaviour, IItem
{
    public GameObject waterTransform = null;
    
    private bool isFilled = false;
    private bool canFill = false;

    private void Start()
    {
        canFill = false;
        isFilled = false;
    }

    public void Use()
    {
        canFill = true;
        if (isFilled)
        {
            Debug.Log("eys filled");
            waterTransform.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canFill)
        {
            if (other.transform.CompareTag("Ocean"))
            {
                isFilled = true;
            }
        }
    }
}
