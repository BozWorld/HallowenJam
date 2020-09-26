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
        textDisplay = GameObject.Find("TextBox").GetComponent<TextMeshProUGUI>();
        
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
                for (int i = 0; i < _ButtonInteraction.Count; i++)
                {
                _ButtonInteraction[i] = GameObject.Find("UiManager").GetComponent<UiManager>().ChoiceButton[i];   
                int __choiceIdx = _dialogueList[index].ChoiceIdx[y];
                _ButtonInteraction[y].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _dialogueList[__choiceIdx].text;
                _ButtonInteraction[i].SetActive(true);
                y++; 
                }
                foreach (GameObject i in _ButtonInteraction)
                {
                
                }
                 //int choiceIdx = _dialogueList[index].ChoiceIdx1;
                //_ButtonInteraction[0].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _dialogueList[choiceIdx].text;
                break;
    
            default:
                break;
        }
    }
    public void ChoiceMaker(int ChoiceParameter)
    {
            index = ChoiceParameter; 
            textDisplay.text = "";
            StartCoroutine(Type());
    }

}
