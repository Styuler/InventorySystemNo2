using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item(0, "Diamond Sword", "A Sword made out of Diamond", new Dictionary<string, int>
            {
                {"Power",15},
                {"Defence",10},
            }),
            
            new Item(1, "Diamond Pick", "A Pick made out of Diamond", new Dictionary<string, int>
            {
                {"Power",10},
                {"Mining",100},
            }),
            
            new Item(2, "Diamond Ore", "A Diamond", new Dictionary<string, int>
            {
                {"Value",500},
            }),
            
            new Item(3, "Silver Pick", "A Pick made out of Silver", new Dictionary<string, int>
            {
                {"Power",5},
                {"Defence",50},
            }),
            
            new Item(4, "Emerald Ore", "An Emerald", new Dictionary<string, int>
            {
                {"Value", 400},
            }),
            
            new Item(5, "Gold Ore", "A piece of Gold", new Dictionary<string, int>
            {
                {"Value",200},
            }),
        };
    }
}
