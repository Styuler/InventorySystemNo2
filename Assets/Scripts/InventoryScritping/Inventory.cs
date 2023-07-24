using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    void Start()
    {
        inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        GiveItem(0);
        GiveItem(2);
        GiveItem(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }

        if (characterItems.Contains(itemDatabase.GetItem(2)))
        {
            //Debug.Log("heyho");
            
        }
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Removed item: " + itemToRemove.title);
        }
    }
}
