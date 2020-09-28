using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameZone;
    public GameObject _UiManager;
    public int[] __choiceidx;
    public string characterName;
    public Image minionDescriptionUI;
    public Sprite minionSprite;
    public Image imageVisage;
    public Sprite[] spriteVisage;
    public int _faceIdx;
    public Image characterImage;
    public Sprite characterSprite;
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
        
        if (textDisplay.text == _dialogueList[index].text)
        {
            continueButton.SetActive(true);
        }
        if (textDisplay.text == _dialogueList[index].text && _dialogueList[index].type == DialogueLine.DialogueType.Choice)
        {
            for (int i = 0; i < _ButtonInteraction.Count; i++) 
            {
                _ButtonInteraction[i].SetActive(true);
            }
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
        if (index < _dialogueList.Count -1 && _dialogueList[index].type == DialogueLine.DialogueType.Dialogue || index < _dialogueList.Count -1 && _dialogueList[index].type == DialogueLine.DialogueType.Dialogue )
        {
            index = _dialogueList[index].nextLineIndex;
            imageVisage.sprite = spriteVisage[_dialogueList[index].faceIdx];
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        switch (_dialogueList[index].type)
        {
            case DialogueLine.DialogueType.GoodEnd:
                textDisplay.text = "";
                _Player.canPlayerInteract = true;
                _Player.minionsCount +=1;
                continueButton.SetActive(false);
                this.gameObject.SetActive(false);
                _UiManager.SetActive(false);
                break;
            case DialogueLine.DialogueType.BadEnd:
                textDisplay.text = "";
                _Player.canPlayerInteract = true;
                _Player.minionsCount -=1;
                continueButton.SetActive(false);
                this.gameObject.SetActive(false);
                _UiManager.SetActive(false);
                break;
            case DialogueLine.DialogueType.Choice:
                for (int i = 0; i < _ButtonInteraction.Count; i++)
                {
                _ButtonInteraction[i] = _UiManager.GetComponent<UiManager>().ChoiceButton[i];   
                __choiceidx[i] = _dialogueList[index].ChoiceIdx[i];
                _ButtonInteraction[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _dialogueList[__choiceidx[i]].text;
                }
                break;
            default:
                break;
        }  
        }
        
    }
    public void ChoiceMaker(int ChoiceParameter)
    {
        if (this.gameObject.activeSelf){
            index = _dialogueList[__choiceidx[ChoiceParameter]].nextLineIndex;
            textDisplay.text = "";
            StartCoroutine(Type());
            for (int i = 0; i < _ButtonInteraction.Count ; i++)
            {
                _ButtonInteraction[i].SetActive(false);
            }
        }
            
    }
    public void OnEnable() {
        Debug.Log("ok");
        _Player.canPlayerInteract = false;
        _UiManager.SetActive(true);
        nameZone.GetComponent<TextMeshProUGUI>().text = characterName;
        minionDescriptionUI.sprite = minionSprite;
        characterImage.sprite = characterSprite;
        imageVisage.sprite = spriteVisage[0];
        StartCoroutine(Type());
    }
    private void OnDisable() {
        textDisplay.text = "";
        index = 0;
        StopCoroutine(Type());

    }

}
