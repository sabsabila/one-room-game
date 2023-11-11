using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float runSpeed = 20.0f;

    private Rigidbody2D body;
    private float horizontal;
    private float vertical;

    private bool canMove;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
    }

    private void OnEnable()
    {
        InteractableManager.OnChoicePanelOpened += FreezeMovement;
        InteractableManager.OnChoicePanelClosed += UnfreezeMovement;
        DialogueManager.OnDialogueStarted += FreezeMovement;
        DialogueManager.OnDialogueEnded += UnfreezeMovement;
    }

    private void OnDisable()
    {
        InteractableManager.OnChoicePanelOpened -= FreezeMovement;
        InteractableManager.OnChoicePanelClosed -= UnfreezeMovement;
        DialogueManager.OnDialogueStarted -= FreezeMovement;
        DialogueManager.OnDialogueEnded -= UnfreezeMovement;
    }

    private void FreezeMovement()
    {
        canMove = false;
    }

    private void UnfreezeMovement()
    {
        canMove = true;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
