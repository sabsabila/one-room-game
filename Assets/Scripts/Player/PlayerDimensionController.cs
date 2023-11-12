using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDimensionController : MonoBehaviour
{
    private bool _canSwitch;

    #region Unity Functions

    private void Start()
    {
        _canSwitch = true;
    }

    private void Update()
    {
        if (_canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DimensionManager.Instance.SwitchDimension();
            }
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

    #endregion

    private void EnableSwitch()
    {
        _canSwitch = true;
    }

    private void DisableSwitch()
    {
        _canSwitch = false;
    }

    #region Callbacks

    private void HandleOnChoicePanelOpened()
    {
        DisableSwitch();
    }

    private void HandleOnChoicePanelClosed()
    {
        EnableSwitch();
    }

    private void HandleOnDialogueStart()
    {
        DisableSwitch();
    }

    private void HandleOnDialogueEnd()
    {
        EnableSwitch();
    }

    #endregion
}
