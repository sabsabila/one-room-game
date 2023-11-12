using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _endingNoteTMP;

    private void Start()
    {
        _endingNoteTMP.text = GameManager.EndingNote;

        FadeManager.Instance.FadeIn();
    }
}
