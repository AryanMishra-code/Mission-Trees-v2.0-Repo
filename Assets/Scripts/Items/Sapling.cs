using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{
    [Tooltip("Array length should be equl to growthStagePrefabs' array length")]
    public float[] waterLevelsForGrowthStages = new float[3];
    private int growthStage = 10;
    public List<GameObject> growthStagePrefabs = new List<GameObject>();

    private GameObject currentSapling = null;
    private float currentWaterLevel = 0f;

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode.P))) UpdateGrowthStage(10f);
    }
    
    private void UpdateGrowthStage(float waterAmt)
    {
        currentWaterLevel += waterAmt;
        
        if (currentSapling != null)
            Destroy(currentSapling);
        
        for (int i = 0; i < waterLevelsForGrowthStages.Length; i++)
        {
            if (currentWaterLevel >= waterLevelsForGrowthStages[i])
                growthStage = i;
            else 
                break;
        }

        try
        {
            currentSapling = Instantiate(growthStagePrefabs[growthStage], transform);
        }
        catch (ArgumentOutOfRangeException e)
        {
            // do nothing
        }
    }
}
