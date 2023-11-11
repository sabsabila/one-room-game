using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private InteractableChoicePanel _choicePanel;

    #region Actions

    public static event Action OnChoicePanelOpened;
    public static event Action OnChoicePanelClosed;

    public static void OpenChoicePanel()
    {
        OnChoicePanelOpened?.Invoke();
    }

    public static void CloseChoicePanel()
    {
        OnChoicePanelClosed?.Invoke();
    }

    #endregion

    public void ToggleNamePanel(List<Interactables> interactableList)
    {
        if(interactableList != null && interactableList.Count > 0)
        {
            _choicePanel.ShowInteractableName(interactableList[0].objectName);
        }
        else
        {
            _choicePanel.HideInteractableName();
        }
    }

    public void InitChoices(List<Interactables.InteractDialogue> interactionList)
    {
        foreach (var interaction in interactionList)
        {
            _choicePanel.GenerateChoiceButton(interaction);
        }

        _choicePanel.GenerateCancelButton();
        _choicePanel.ShowChoicePanel();
    }

    #region Instance

    public static InteractableManager Instance;

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
