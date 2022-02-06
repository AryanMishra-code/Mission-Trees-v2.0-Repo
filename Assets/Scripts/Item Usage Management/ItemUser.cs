using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUser : MonoBehaviour
{
    public Camera cam;
    public float range = 10f;
    public Transform itemHolder = null;

    private IItem currentItem = null;
    public List<IItem> itemsInInventory = new List<IItem>();

    private int currentIndex = 0;

    [Header("Text Objects")]
    public TextMeshProUGUI plantCountText = null;
    
    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1)) currentIndex = 0;
        // if (Input.GetKeyDown(KeyCode.Alpha2)) currentIndex = 1;
        // if (Input.GetKeyDown(KeyCode.Alpha3)) currentIndex = 2;
        //
        // currentItem = itemsInInventory[currentIndex];
        //
        // if (Input.GetMouseButtonDown(1))
        // {
        //     if (currentItem != null)
        //         currentItem.Use();
        // }
    }

    public void PickupItem(GameObject pickup)
    {
        var item = Instantiate(pickup, itemHolder);
    }
    
    public void AddItem(IItem item)
    {
        itemsInInventory.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        itemsInInventory.Remove(item);
    }
}
