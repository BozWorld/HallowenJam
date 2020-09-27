using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameZone;
    public string Name;
    public GameObject continueButton;
    [SerializeField] private List<GameObject> _ButtonInteraction = null;
    public Player _Player;  
    public float typingSpeed;
    [SerializeField] private List<DialogueLine> _dialogueList = new List<DialogueLine>();
    private int index;
    private int buttonidx;
    
    
    private void Start() 
    {
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
        if (this.gameObject.activeSelf)
        {
            continueButton.SetActive(false);
        if (index < _dialogueList.Count -1 )
        {
            Debug.Log(index);
            index = _dialogueList[index].nextLineIndex;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        switch (_dialogueList[index].type)
        {
            case DialogueLine.DialogueType.GoodEnd:
                textDisplay.text = "";
                _Player.canPlayerInteract = true;
                _Player.minionsCount +=1;
                GameObject.Find("UiManager").SetActive(false);
                break;
            case DialogueLine.DialogueType.BadEnd:
                textDisplay.text = "";
                _Player.canPlayerInteract = true;
                GameObject.Find("UiManager").SetActive(false);
                break;
            case DialogueLine.DialogueType.Choice:
                for (int i = 0; i < _ButtonInteraction.Count; i++)
                {
                _ButtonInteraction[i] = GameObject.Find("UiManager").GetComponent<UiManager>().ChoiceButton[i];   
                int __choiceIdx = _dialogueList[index].ChoiceIdx[i];
                _ButtonInteraction[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _dialogueList[__choiceIdx].text;
                _ButtonInteraction[i].SetActive(true);
                }
                break;
            default:
                break;
        }  
        }
        
    }
    public void ChoiceMaker(int ChoiceParameter = 1)
    {
        if (this.gameObject.activeSelf){
            index = ChoiceParameter; 
            textDisplay.text = "";
            StartCoroutine(Type());
        }
            
    }
    public void OnEnable() {
        _Player.canPlayerInteract = false;
        GameObject.Find("UiManager").SetActive(true);
        StartCoroutine(Type());
        nameZone.GetComponent<TextMeshProUGUI>().text = name;
    }

}
