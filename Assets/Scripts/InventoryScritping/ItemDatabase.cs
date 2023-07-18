using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();

    void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item=> item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "Diamond Sword", "A sword made of diamond.",
            new Dictionary<string, int> {
                { "Attack", 15 },
                { "Attack speed", 7 }
            }),
            new Item(1, "Diamond Ore", "A little diamond.",
            new Dictionary<string, int> {
                { "Value", 300 }
            }),
            new Item(2, "Silver Pick", "A silver pick.",
            new Dictionary<string, int> {
                { "Attack", 5 },
                { "Mining", 20}
            })
        };
    }
}
