using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDialogueManager : MonoBehaviour
{
    [SerializeField] private List<DialogueScriptableObject> _randomDialogueList;

    private bool canPlay = false;

    private void Start()
    {
        canPlay = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canPlay)
        {
            PlayRandomDialogue();
        }
    }

    private void OnEnable()
    {
        InteractableManager.OnChoicePanelOpened += HandleOnChoicePanelOpened;
        InteractableManager.OnChoicePanelClosed += HandleOnChoicePanelClosed;
        DialogueManager.OnDialogueStarted += HandleOnDialogueStart;
        DialogueManager.OnDialogueEnded += HandleOnDialogueEnd;
    }

    private void OnDisable()
    {
        InteractableManager.OnChoicePanelOpened -= HandleOnChoicePanelOpened;
        InteractableManager.OnChoicePanelClosed -= HandleOnChoicePanelClosed;
        DialogueManager.OnDialogueStarted -= HandleOnDialogueStart;
        DialogueManager.OnDialogueEnded -= HandleOnDialogueEnd;
    }

    public void PlayRandomDialogue()
    {
        int idx = Random.Range(0, _randomDialogueList.Count);

        DialogueManager.Instance.SetActiveLines(_randomDialogueList[idx].Lines);
    }

    private void EnableDialogue()
    {
        canPlay = true;
    }

    private void DisableDialogue()
    {
        canPlay = false;
    }

    #region Callbacks

    private void HandleOnChoicePanelOpened()
    {
        DisableDialogue();
    }

    private void HandleOnChoicePanelClosed()
    {
        EnableDialogue();
    }

    private void HandleOnDialogueStart()
    {
        DisableDialogue();
    }

    private void HandleOnDialogueEnd()
    {
        EnableDialogue();
    }

    #endregion
}
