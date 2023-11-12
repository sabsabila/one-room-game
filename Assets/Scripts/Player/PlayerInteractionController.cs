using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private GameObject _prompt;

    [SerializeField] private List<Interactables> _interactableList = new List<Interactables>();

    private bool _canInteract;

    #region Unity Functions

    private void Start()
    {
        TogglePrompt();

        _canInteract = false;
    }

    private void Update()
    {
        if (CheckInteractablesExist() && Input.GetKeyDown(KeyCode.E) && _canInteract)
        {
            Interact();
        }
    }

    private void OnEnable()
    {
        DialogueManager.OnDialogueStarted += HandleOnDialogueStart;
        DialogueManager.OnDialogueEnded += HandleOnDialogueEnd;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueStarted -= HandleOnDialogueStart;
        DialogueManager.OnDialogueEnded -= HandleOnDialogueEnd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            AddInteractables(collision.GetComponent<Interactables>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            RemoveInteractables(collision.GetComponent<Interactables>());
        }
    }

    #endregion

    private void Interact()
    {
        _interactableList[0].ShowInteractionChoice();
    }

    private void AddInteractables(Interactables interactable)
    {
        if (!_interactableList.Contains(interactable))
        {
            _interactableList.Add(interactable);
        }

        TogglePrompt();
    }

    private void RemoveInteractables(Interactables interactable)
    {
        if (_interactableList.Contains(interactable))
        {
            _interactableList.Remove(interactable);
        }

        TogglePrompt();
    }

    private bool CheckInteractablesExist()
    {
        return _interactableList != null && _interactableList.Count > 0;
    }

    private void TogglePrompt()
    {
        if (_interactableList.Count > 0)
        {
            _prompt.SetActive(true);
        }
        else
        {
            _prompt.SetActive(false);
        }

        InteractableManager.Instance.ToggleNamePanel(_interactableList);
    }

    private void EnableInteraction()
    {
        _canInteract = true;
        Debug.Log(">>> can Interact : " + _canInteract + " || " + DialogueManager.Instance.CheckIsDialogueActive());
    }

    private void DisableInteraction()
    {
        _canInteract = false;
        Debug.Log(">>> can Interact : " + _canInteract);
    }

    #region Callbacks

    private void HandleOnDialogueStart()
    {
        DisableInteraction();

        _prompt.SetActive(false);
    }

    private void HandleOnDialogueEnd()
    {
        EnableInteraction();

        TogglePrompt();
    }

    #endregion
}
