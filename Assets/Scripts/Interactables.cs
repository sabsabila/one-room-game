using UnityEngine;
using System.Collections.Generic;
using System;

public class Interactables : MonoBehaviour
{
    [Serializable]
    public struct InteractDialogue
    {
        public string Action;
        public DialogueScriptableObject Dialogue;
    }

    public string objectName;
    [SerializeField] private List<InteractDialogue> _interactionList;
    public DialogueScriptableObject[] dialogues;
    public List<string> actions;

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

        dialogueMap = new Dictionary<string, string[]>();
        for(int i = 0; i < actions.Count; i++)
        {
            dialogueMap.Add(actions[i], dialogues[i].lines);
        }
    }

    public void ShowInteractionChoice()
    {
        InteractableManager.Instance.InitChoices(_interactionList);
    }

    //protected void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E) && isCollided)
    //    {
    //        uiManager.SetMenuPanelActive(true);
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        isCollided = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        isCollided = false;

    //        uiManager.SetMenuPanelActive(false);
    //    }
    //}

}
