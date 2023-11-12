using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Action/Buy")]
public class Buy : InteractAction
{
    public Item UsedItem;
    public Item GainedItem;

    public override void Interact()
    {
        InventoryManager.Instance.RemoveItemFromInventory(UsedItem.itemName);
        InventoryManager.Instance.AddItemToInventory(GainedItem.itemName);
        base.Interact();
    }

    public override bool CheckCanGenerateButton()
    {
        var canGenerate = base.CheckCanGenerateButton();

        canGenerate = InventoryManager.Instance.CheckItemExist(UsedItem.itemName) && !InventoryManager.Instance.CheckDialogueExist(DialogueList[0].Dialogue.DialogueId);

        return canGenerate;
    }
}
