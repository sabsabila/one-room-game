using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    public float runSpeed = 20.0f;

    private Rigidbody2D body;
    private float horizontal;
    private float vertical;

    private bool canMove;

    private Animator _anim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        canMove = false;
    }

    void Update()
    {
        if (canMove && !DialogueManager.Instance.CheckIsDialogueActive())
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        if(horizontal != 0 || vertical != 0)
        {
            _anim.SetBool("isWalking", true);
        }
        else
        {
            _anim.SetBool("isWalking", false);
        }

        if(horizontal >= 0)
        {
            _model.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            _model.transform.localScale = new Vector3(-1, 1, 1);
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
        horizontal = 0;
        vertical = 0;
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
