using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemListPrefab;
    public Transform inventoryListPool;

    private List<string> items;

    void Start()
    {
        items = new List<string>();
    }
    
    public void AddToInventory(string name)
    {
        if (!CheckItemExist(name))
        {
            items.Add(name);
            var inventory = Instantiate(itemListPrefab, inventoryListPool);
            inventory.name = name;
            inventory.GetComponentInChildren<TextMeshProUGUI>().text = name;
        }
    }

    public void RemoveFromInventory(string name)
    {
        if (CheckItemExist(name))
        {
            items.Remove(name);
            Destroy(inventoryListPool.Find(name).gameObject);
        }
    }

    public bool CheckItemExist(string name)
    {
        return items.Contains(name);
    }

    public void SetPanelActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
