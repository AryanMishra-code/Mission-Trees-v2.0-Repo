using System;
using UnityEngine;

namespace Items
{
    public class SaplingContainer : MonoBehaviour, IItem
    {
        public GameObject plantSapling;

        [HideInInspector] public int numberOfSaplingsPlanted;

        private ItemUser itemUser;

        private void Start()
        {
            itemUser = FindObjectOfType<ItemUser>();
        }

        public void Use()
        {
            RaycastHit hit;
        
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, itemUser.range))
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    Instantiate(plantSapling, hit.point, Quaternion.identity);
                    numberOfSaplingsPlanted++;
                    itemUser.plantCountText.text = numberOfSaplingsPlanted.ToString();
                }
            }
        }
    }
}