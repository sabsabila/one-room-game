using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Action/Take")]
public class Take : InteractAction
{
    public Item Item;
    public bool IsRepeatable = false;

    public override void Interact()
    {
        InventoryManager.Instance.AddItemToInventory(Item.itemName);
        base.Interact();
    }

    public override bool CheckCanGenerateButton()
    {
        var canGenerate = base.CheckCanGenerateButton();

        canGenerate = !InventoryManager.Instance.CheckItemExist(Item.itemName);

        if (!IsRepeatable)
        {
            canGenerate = canGenerate && !InventoryManager.Instance.CheckDialogueExist(DialogueList[0].Dialogue.DialogueId);
        }
        
        return canGenerate;
    }
}
