using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableChoiceButton : MonoBehaviour
{
    private string action;
    private DialogueScriptableObject _dialogue;

    private Button _btn;

    public void InitComponent(Interactables.InteractDialogue interaction)
    {
        _btn = GetComponent<Button>();
        _dialogue = interaction.Dialogue;

        GetComponentInChildren<TextMeshProUGUI>().text = interaction.Action;

        _btn.onClick.AddListener(PlayDialogue);
    }

    private void PlayDialogue()
    {
        DialogueManager.Instance.SetActiveDialogue(_dialogue.lines, "MC");
        DialogueManager.Instance.SetDialoguePanelActive(true);
        UIManager.Instance.SetMenuPanelActive(false);
    }
}
