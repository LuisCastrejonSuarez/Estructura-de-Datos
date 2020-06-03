using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Dictionary<string, GameObject> backpackDictionary;
    public GameObject item;

    void Start()
    {
        backpackDictionary = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            string key = DateTime.Now.ToString();
            backpackDictionary.Add(key, item);
            Debug.Log(string.Format("{0}, {1}", key, item.name));
            GameObject o = backpackDictionary[key];
        }
    }
}
