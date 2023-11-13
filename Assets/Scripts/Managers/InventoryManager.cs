using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemListPrefab;
    public Transform inventoryListPool;
    [SerializeField] private GameObject _contentPanel;

    private List<string> items;
    [SerializeField] private List<string> dialogues;

    void Start()
    {
        items = new List<string>();
        dialogues = new List<string>();
    }
    
    public void AddItemToInventory(string name)
    {
        if (!CheckItemExist(name))
        {
            items.Add(name);
            var inventory = Instantiate(itemListPrefab, inventoryListPool);
            inventory.name = name;
            inventory.GetComponentInChildren<TextMeshProUGUI>().text = name;
        }
    }

    public void RemoveItemFromInventory(string name)
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

    public void AddDialogueToInventory(string name)
    {
        if (!CheckDialogueExist(name))
        {
            dialogues.Add(name);
        }
    }

    public void RemoveDialogueFromInventory(string name)
    {
        if (CheckDialogueExist(name))
        {
            dialogues.Remove(name);
        }
    }

    public bool CheckDialogueExist(string name)
    {
        return dialogues.Contains(name);
    }

    public void SetPanelActive(bool isActive)
    {
        _contentPanel.SetActive(isActive);
    }

    #region Instance

    public static InventoryManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
}
