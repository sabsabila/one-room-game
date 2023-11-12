using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    [SerializeField] private Image _charaAvatar;
    [SerializeField] private TMP_Text _charaNameTMP;
    public List<DialogueLines> activeLines;
    public string[] lines;
    public float textSpeed;
    private int index;

    [SerializeField] private GameObject _content;

    void Start()
    {
        dialogueText.text = "";
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(dialogueText.text == activeLines[index].line)
            {
                NextLine();
            } else
            {
                StopAllCoroutines();
                dialogueText.text = activeLines[index].line;
            }
        }
    }

    public void StartDialogue()
    {
        dialogueText.text = "";
        DialogueManager.StartDialogue();
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        SetCharacterAvatar(activeLines[index]);
        SetCharacterName(activeLines[index]);

        foreach(char c in activeLines[index].line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < activeLines.Count - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _content.SetActive(false);
            DialogueManager.EndDialogue();
        }
    }

    private void SetCharacterName(DialogueLines line)
    {
        if(line.owner == EDialogueOwner.Narrator)
        {
            _charaNameTMP.text = "";
        }
        else
        {
            _charaNameTMP.text = EDialogueOwner.Ica.ToString();
        }
    }

    private void SetCharacterAvatar(DialogueLines line)
    {
        var sprite = DialogueManager.Instance.GetCharacterSprite(line.owner);

        if(sprite != null)
        {
            _charaAvatar.sprite = sprite;
            _charaAvatar.enabled = true;
        }
        else
        {
            _charaAvatar.enabled = false;
        }
        
    }
}
