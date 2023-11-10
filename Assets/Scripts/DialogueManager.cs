using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Dialogue dialogue;

    //private string[] activeDialogue;
    //private string activeCharacter;

    public void SetActiveDialogue(string[] _activeDialogue, string _activeCharacter)
    {
        //activeDialogue = _activeDialogue;
        //activeCharacter = _activeCharacter;

        dialogue.lines = _activeDialogue;
    }

    public void SetDialoguePanelActive(bool isActive)
    {
        dialoguePanel.SetActive(isActive);
    }
}
