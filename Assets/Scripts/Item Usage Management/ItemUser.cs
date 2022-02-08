using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class ItemUser : MonoBehaviour
{
    public Camera cam;
    public float range = 10f;
    public Transform itemHolder = null;

    private IItem currentItem = null;
    private GameObject currentItemObject;
    public List<IItem> itemsInInventory = new List<IItem>();

    private int currentIndex = 0;

    [Header("Text Objects")]
    public Text plantCountText = null;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentIndex = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentIndex = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentIndex = 2;
        
        if (itemsInInventory.Count > currentIndex)
        {
            currentItem = itemsInInventory[currentIndex];
            // currentItemObject = itemHolder.transform.GetChild(currentIndex).gameObject;
            // currentItemObject.SetActive(true);
            // foreach (Transform child in itemHolder) if (child.gameObject != currentItemObject) child.gameObject.SetActive(false);
            EquipItem(itemHolder.transform.GetChild(currentIndex).gameObject);
        }
        else
        {
            currentItem = null;
            foreach (Transform obj in itemHolder) obj.gameObject.SetActive(false);
        }

        
        if (Input.GetMouseButtonDown(1))
        {
            if (currentItem != null)
                currentItem.Use();
        }
    }

    public void EquipItem(GameObject item)
    {
        item.gameObject.SetActive(true);
        foreach (Transform t in itemHolder)
        {
            if (t != item.transform)
            {
                t.gameObject.SetActive(false);
            }
        }

        currentItem = item.GetComponent(typeof(IItem)) as IItem;
    }
    
    public void PickupItem(GameObject pickup)
    {
        var item = Instantiate(pickup, itemHolder);
        foreach (var i in item.GetComponents<MonoBehaviour>().OfType<IItem>())
            AddItem(i);
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
