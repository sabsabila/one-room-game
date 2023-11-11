using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private TextMeshProUGUI objectName;
    [SerializeField] private Transform actionButtonsPool;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private InventoryManager inventoryManager;

    public void AddActionButton(Action buttonAction, string text)
    {
        var button = Instantiate(buttonPrefab, actionButtonsPool);
        button.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
        button.onClick.AddListener(()=> { buttonAction(); });
    }

    public void SetObjectName(string name)
    {
        objectName.text = name;
    }

    public void SetMenuPanelActive(bool isActive)
    {
        if (menuPanel)
        {
            menuPanel.SetActive(isActive);
        }
    }

    //for debugging only
    public void AddItem(string name)
    {
        inventoryManager.AddToInventory(name);
    }

    //for debugging only
    public void RemoveItem(string name)
    {
        inventoryManager.RemoveFromInventory(name);
    }
}
