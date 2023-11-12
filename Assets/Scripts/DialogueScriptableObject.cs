using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/DialogueSO", order = 1)]
public class DialogueScriptableObject : ScriptableObject
{
    public string DialogueId;
    public string[] lines;
    public List<DialogueLines> Lines;
}
