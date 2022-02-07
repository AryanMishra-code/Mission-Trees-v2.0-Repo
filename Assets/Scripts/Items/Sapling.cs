using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{
    private int growthStage = 0;
    public List<GameObject> growthStagePrefabs = new List<GameObject>();

    private GameObject currentSapling = null;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UpdateGrowthStage();
        }
    }

    private void UpdateGrowthStage()
    {
        if (currentSapling != null)
            Destroy(currentSapling);
        currentSapling = Instantiate(growthStagePrefabs[growthStage], transform);
        growthStage++;
        growthStage = Mathf.Clamp(growthStage, 0, growthStagePrefabs.Count - 1);
    }
}
