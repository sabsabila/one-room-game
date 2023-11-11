using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableChoiceButton : MonoBehaviour
{
    private string _actionName;
    private DialogueScriptableObject _dialogue;
    private InteractAction _action;

    private Button _btn;

    public void InitComponent(InteractAction action)
    {
        _btn = GetComponent<Button>();
        _action = action;

        GetComponentInChildren<TextMeshProUGUI>().text = action.InteractionName;

        _btn.onClick.AddListener(PlayDialogue);
    }

    private void PlayDialogue()
    {
        _action.Interact();
    }
}
