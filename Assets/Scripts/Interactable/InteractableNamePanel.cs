using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableNamePanel : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private TMP_Text _interactableNameTMP;

    public void ShowInteractableName(string _name)
    {
        _interactableNameTMP.text = _name;

        TogglePanel(true);
    }

    public void HideInteractableName()
    {
        TogglePanel(false);

        _interactableNameTMP.text = "";
    }

    private void TogglePanel(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
}
