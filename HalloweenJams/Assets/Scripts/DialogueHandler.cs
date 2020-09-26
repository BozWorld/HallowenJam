using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [SerializeField] private List<DialogueLine> _dialogueList = new List<DialogueLine>();
    private int index;
    private int buttonidx;
    public float typingSpeed;
    public GameObject continueButton;
    [SerializeField] private List<GameObject> _ButtonInteraction = null;
    private void Start() 
    {
        StartCoroutine(Type());
    }
    void Update()
    {
        if (textDisplay.text == _dialogueList[index].text && _dialogueList[index].type == DialogueLine.DialogueType.Dialogue)
        {
            continueButton.SetActive(true);
        }
    }

    //gère le défilement de lettre
    IEnumerator Type(){
        foreach (char letter in _dialogueList[index].text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //gère les différent type de text et la continuation du text
    public void ContinueText()
    {
        continueButton.SetActive(false);
        if (index < _dialogueList.Count -1 )
        {
            index = _dialogueList[index].nextLineIndex;
            textDisplay.text = "";
            StartCoroutine(Type());

        } 
        switch (_dialogueList[index].type)
        {
            case DialogueLine.DialogueType.End:
                textDisplay.text = "";
                break;

            case DialogueLine.DialogueType.Choice:
                int y = 0;
                foreach (GameObject i in _ButtonInteraction)
                {
                int __choiceIdx = _dialogueList[index].ChoiceIdx[y];
                _ButtonInteraction[y].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _dialogueList[__choiceIdx].text;
                i.SetActive(true);
                y++;
                }
                 //int choiceIdx = _dialogueList[index].ChoiceIdx1;
                //_ButtonInteraction[0].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _dialogueList[choiceIdx].text;
                break;
    
            default:
                break;
        }
    }
    public void ChoiceMaker()
    {
            Debug.Log(index);
            index = _dialogueList[index].nextLineIndex;
            textDisplay.text = "";
            StartCoroutine(Type());
    }

}
