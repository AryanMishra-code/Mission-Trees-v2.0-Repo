using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUsageManagement : MonoBehaviour
{
    [Header("Equipment Status Checks")]
    [SerializeField] private Text plantContainerEquipmentStatus;

    [Header("Item Usage Variables Ref.")]
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 10f;
    [SerializeField] private GameObject plantSapling;
    [SerializeField] private Text countOfPlants;

    private int _numberOfPlantsPlanted = 0;

    [Header("Booleans For Equipment Checks")]
    public bool hasEquippedPlant;
    public bool hasEquippedBucket;
    public bool hasEquippedFenceWood;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (hasEquippedPlant)
            {
                PlantSapling();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (hasEquippedBucket)
            {
                PlantIrrigation();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (hasEquippedFenceWood)
            {
                PlantAreaFencing();
            }
        }
    }

    private void PlantSapling()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Terrain Tag")
            {
                Instantiate(plantSapling, hit.point, Quaternion.identity);
                _numberOfPlantsPlanted++;
                countOfPlants.text = _numberOfPlantsPlanted.ToString();
            }
        }
    }

    private void PlantIrrigation()
    {
        // TODO
    }

    private void PlantAreaFencing()
    {
        // TODO
    }
}