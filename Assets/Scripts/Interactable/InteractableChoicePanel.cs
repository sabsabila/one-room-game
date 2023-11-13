using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableChoicePanel : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private GameObject _objectNamePanel;
    [SerializeField] private TMP_Text _objectNameTMP;
    [SerializeField] private GameObject _buttonContainer;

    [Header("Prefabs")]
    [SerializeField] private GameObject _buttonPrefab;

    private List<GameObject> _choiceButtonList = new List<GameObject>();

    #region Unity Functions

    private void OnEnable()
    {
        DialogueManager.OnDialogueStarted += HandleOnDialogueStart;
    }

    private void OnDisable()
    {
        DialogueManager.OnDialogueStarted -= HandleOnDialogueStart;
    }

    #endregion

    public void ShowInteractableName(string _name)
    {
        _objectNameTMP.text = _name;

        ToggleNamePanel(true);
    }

    public void HideInteractableName()
    {
        ToggleNamePanel(false);

        _objectNameTMP.text = "";
    }

    public void ShowChoicePanel()
    {
        ToggleChoicePanel(true);

        InteractableManager.OpenChoicePanel();
    }

    public void HideChoicePanel()
    {
        ToggleChoicePanel(false);
        ResetChoiceButtonList();

        InteractableManager.CloseChoicePanel();
    }

    public void GenerateChoiceButton(InteractAction action)
    {
        var btn = Instantiate(_buttonPrefab, _buttonContainer.transform).GetComponent<InteractableChoiceButton>();

        btn.InitComponent(action);

        _choiceButtonList.Add(btn.gameObject);
    }

    public void GenerateCancelButton()
    {
        var btn = Instantiate(_buttonPrefab, _buttonContainer.transform).GetComponent<Button>();

        btn.GetComponentInChildren<TextMeshProUGUI>().text = "Cancel";
        btn.onClick.AddListener(HideChoicePanel);

        _choiceButtonList.Add(btn.gameObject);
    }

    public bool IsChoicePanelActive()
    {
        return _buttonContainer.activeSelf;
    }

    private void ResetChoiceButtonList()
    {
        foreach(var btn in _choiceButtonList)
        {
            Destroy(btn);
        }

        _choiceButtonList = new List<GameObject>();
    }

    private void ToggleNamePanel(bool isVisible)
    {
        if (_objectNamePanel)
        {
            _objectNamePanel.SetActive(isVisible);
        }
    }

    private void ToggleChoicePanel(bool isVisible)
    {
        _buttonContainer.SetActive(isVisible);
    }

    #region Callbacks

    private void HandleOnDialogueStart()
    {
        ToggleChoicePanel(false);
        ResetChoiceButtonList();
    }

    #endregion
}
