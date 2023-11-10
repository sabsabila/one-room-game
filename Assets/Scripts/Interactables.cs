using UnityEngine;
using System.Collections.Generic;

public class Interactables : MonoBehaviour
{
    public string objectName;
    public DialogueScriptableObject[] dialogues;
    public string[] actions;

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
        for(int i = 0; i < actions.Length; i++)
        {
            dialogueMap.Add(actions[i], dialogues[i].lines);
        }
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollided)
        {
            uiManager.SetMenuPanelActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCollided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCollided = false;

            uiManager.SetMenuPanelActive(false);
        }
    }

}
