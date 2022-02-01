using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsUsageManagement : MonoBehaviour
{
    [SerializeField] private Text equipmentStatus;

    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 10f;
    [SerializeField] private GameObject plantSapling;
    [SerializeField] private Text countOfPlants;

    private int _numberOfPlantsPlanted = 0;
    
    void Update()
    {
        if (equipmentStatus.text == "EQUIPPED")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                PlantSapling();
            }
        }
    }

    private void PlantSapling()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Instantiate(plantSapling, hit.point, Quaternion.identity);
            _numberOfPlantsPlanted++;
            countOfPlants.text = _numberOfPlantsPlanted.ToString();
        }
        else
        {
            return;
        }
    }
}
