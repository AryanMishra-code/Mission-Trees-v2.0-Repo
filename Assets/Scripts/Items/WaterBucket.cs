using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Water;

public class WaterBucket : MonoBehaviour, IItem
{
    public GameObject waterTransform = null;
    public float waterPerIrrigation = 10f;
    public float irrigationRange = 1f;
    public LayerMask plantLayer;

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
            waterTransform.gameObject.SetActive(true);
            var plants = FindObjectsOfType<Sapling>();
            if (plants != null)
            {
                foreach (var plant in plants)
                {
                    if (Vector3.Distance(plant.transform.position, transform.position) < irrigationRange)
                        plant.GetComponent<Sapling>().UpdateGrowthStage(waterPerIrrigation);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
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
