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
        menuPanel.SetActive(isActive);
    }
}
