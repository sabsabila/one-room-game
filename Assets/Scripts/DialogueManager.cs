using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Dialogue dialogue;

    #region Actions

    public static event Action OnDialogueStarted;
    public static event Action OnDialogueEnded;

    public static void StartDialogue()
    {
        OnDialogueStarted?.Invoke();
    }

    public static void EndDialogue()
    {
        OnDialogueEnded?.Invoke();
    }

    #endregion

    //private string[] activeDialogue;
    //private string activeCharacter;

    public void SetActiveDialogue(string[] _activeDialogue, string _activeCharacter)
    {
        //activeDialogue = _activeDialogue;
        //activeCharacter = _activeCharacter;

        dialogue.lines = _activeDialogue;
        dialogue.StartDialogue();
    }

    public void SetDialoguePanelActive(bool isActive)
    {
        dialoguePanel.SetActive(isActive);
    }

    public bool CheckIsDialogueActive()
    {
        return dialoguePanel.activeSelf;
    }

    #region Instance

    public static DialogueManager Instance;

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
