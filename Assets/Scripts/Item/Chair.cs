using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : Interactables
{
    private void Start()
    {
        base.Start();
        uiManager.AddActionButton(Sit, "Sit");
    }

    public void Sit()
    {
        Debug.Log("Is sitting...");
        dialogueManager.SetActiveDialogue(dialogueMap["Sit"], "MC");
        dialogueManager.SetDialoguePanelActive(true);
        uiManager.SetMenuPanelActive(false);
    }
}
