using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Action/Use")]
public class Use : InteractAction
{
    public Item Item;
    public bool IsRepeatable;

    public override void Interact()
    {
        InventoryManager.Instance.RemoveItemFromInventory(Item.itemName);
        base.Interact();
    }

    public override bool CheckCanGenerateButton()
    {
        var canGenerate = base.CheckCanGenerateButton();

        canGenerate = InventoryManager.Instance.CheckItemExist(Item.itemName);

        if (!IsRepeatable)
        {
            canGenerate = canGenerate && !InventoryManager.Instance.CheckDialogueExist(DialogueList[0].Dialogue.DialogueId);
        }

        return canGenerate;
    }
}
