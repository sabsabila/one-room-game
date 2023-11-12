using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAction : ScriptableObject
{
    [System.Serializable]
    public struct InteractDialogue
    {
        public DialogueScriptableObject Dialogue;
        public List<Item> RequiredItemList;
        public List<DialogueScriptableObject> RequiredDialogueList;
    }

    public string InteractionName;
    public List<InteractDialogue> DialogueList;
    public RouteRequirement RouteRequirementAcquired;

    public virtual void Interact()
    {
        var dialogue = GetDialogue();

        DialogueManager.Instance.SetActiveLines(dialogue.Lines);
        //DialogueManager.Instance.SetActiveDialogue(dialogue.lines, "MC");
        //DialogueManager.Instance.SetDialoguePanelActive(true);
        //UIManager.Instance.SetMenuPanelActive(false);
        InventoryManager.Instance.AddDialogueToInventory(dialogue.DialogueId);

        DialogueManager.OnDialogueEnded += HandleOnDialogueEnd;
    }

    public virtual bool CheckCanGenerateButton()
    {
        bool canGenerate = false;

        if(DialogueList != null)
        {
            for(int i = DialogueList.Count; i > 0; i--)
            {
                var dialogue = DialogueList[i - 1];

                canGenerate = CheckForRequiredItem(dialogue) && CheckForRequiredDialogue(dialogue);
                Debug.Log(">>> generate : " + dialogue.Dialogue.DialogueId + " | " + CheckForRequiredItem(dialogue) + " + " + CheckForRequiredDialogue(dialogue) + " = " + canGenerate);

                if (canGenerate)
                {
                    break;
                }
            }
        }

        return canGenerate;
    }

    public bool CheckForRequiredItem(InteractDialogue dialogue)
    {
        if (dialogue.RequiredItemList != null && dialogue.RequiredItemList.Count <= 0)
        {
            return true;
        }
        else
        {
            foreach (var item in dialogue.RequiredItemList)
            {
                return InventoryManager.Instance.CheckItemExist(item.itemName);
            }
        }

        return false;
    }

    public bool CheckForRequiredDialogue(InteractDialogue dialogue)
    {
        if (dialogue.RequiredDialogueList != null && dialogue.RequiredDialogueList.Count <= 0)
        {
            return true;
        }
        else
        {
            foreach (var item in dialogue.RequiredDialogueList)
            {
                return InventoryManager.Instance.CheckDialogueExist(item.DialogueId);
            }
        }

        return false;
    }

    public DialogueScriptableObject GetDialogue()
    {
        DialogueScriptableObject activeDialogue = null;

        bool isValid = false;

        if (DialogueList != null)
        {
            for (int i = DialogueList.Count; i > 0; i--)
            {
                var dialogue = DialogueList[i - 1];

                isValid = CheckForRequiredItem(dialogue) && CheckForRequiredDialogue(dialogue);
                Debug.Log(">>> getDialogue : " + dialogue.Dialogue.DialogueId + " | " + CheckForRequiredItem(dialogue) + " + " + CheckForRequiredDialogue(dialogue) + " = " + isValid);

                if (isValid)
                {
                    activeDialogue = dialogue.Dialogue;

                    break;
                }
            }
        }

        return activeDialogue;
    }

    private void HandleOnDialogueEnd()
    {
        if (RouteRequirementAcquired != null)
        {
            RouteManager.Instance.AddRequirementToList(RouteRequirementAcquired.RequirementId);
        }

        DialogueManager.OnDialogueEnded -= HandleOnDialogueEnd;
    }
}
