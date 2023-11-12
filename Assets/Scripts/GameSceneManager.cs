using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private DialogueScriptableObject _startDialogue;
    [SerializeField] private DialogueScriptableObject _firstTimeChangeDimension;

    public bool _isFirstTimeChangingDimension = true;

    private void Start()
    {
        DialogueManager.OnDialogueEnded += HandleOnStartDialogueEnd;
        FadeManager.OnFadeIn += PlayStartDialogue;
        FadeManager.Instance.FadeIn();
    }

    private void PlayStartDialogue()
    {
        DialogueManager.Instance.SetActiveLines(_startDialogue.Lines);
    }

    public void HandleOnStartDialogueEnd()
    {
        GameManager.StartGame();
        DialogueManager.OnDialogueEnded -= HandleOnStartDialogueEnd;
    }

    public void HandleOnFirstTimeChangingDimension()
    {
        if (_isFirstTimeChangingDimension)
        {
            DialogueManager.Instance.SetActiveLines(_firstTimeChangeDimension.Lines);
            _isFirstTimeChangingDimension = false;
        }
    }

    #region Instance

    public static GameSceneManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion
}
