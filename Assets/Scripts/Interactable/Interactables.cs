using UnityEngine;
using System.Collections.Generic;
using System;

public class Interactables : MonoBehaviour
{
    [Serializable]
    public struct InteractDialogue
    {
        public string Name;
        public InteractAction Action;
    }

    public string objectName;
    [SerializeField] private List<InteractAction> _interactActionList;

    protected Dictionary<string, string[]> dialogueMap;
    protected UIManager uiManager;
    protected DialogueManager dialogueManager;
    protected bool isCollided = false;
    protected bool isInInventory = false;

    protected void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        uiManager.SetObjectName(objectName);

    }

    public void ShowInteractionChoice()
    {
        InteractableManager.Instance.InitChoices(_interactActionList);
    }
}
