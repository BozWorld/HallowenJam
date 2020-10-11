using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Minion : LevelEntity
{
    //minionInformation
    public string minionName;
    public minionSO minionSO;
    //UImanager information
    public int[] __choiceidx;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI nameZone;
    public GameObject minionInformation;
    public GameObject _UiManager;
    public Image imageVisage;
    public Image characterImage;
    public Image minionDescriptionUI;
    public float typingSpeed;
    public GameObject continueButton;
    [SerializeField] private List<GameObject> _ButtonInteraction = null;
    //sceneInformation
    private int index;
    private int buttonidx;
    public Player _Player;
    void Start()
    {
       
    }

    void Update()
    {
        
        if (textDisplay.text == minionSO._dialogueList[index].text && minionSO._dialogueList[index].type == DialogueLine.DialogueType.Dialogue || textDisplay.text == minionSO._dialogueList[index].text && minionSO._dialogueList[index].type == DialogueLine.DialogueType.GoodEnd ||textDisplay.text == minionSO._dialogueList[index].text && minionSO._dialogueList[index].type == DialogueLine.DialogueType.BadEnd )
        {
            continueButton.SetActive(true);
        }
        if (textDisplay.text == minionSO._dialogueList[index].text && minionSO._dialogueList[index].type == DialogueLine.DialogueType.Choice)
        {
            continueButton.SetActive(false);
            for (int i = 0; i < _ButtonInteraction.Count; i++) 
            {
                _ButtonInteraction[i].SetActive(true);
            }
        }
    }
    IEnumerator Type(){
        foreach (char letter in minionSO._dialogueList[index].text.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void ContinueText()
    {
        if (this.gameObject.activeSelf)
        {
            continueButton.SetActive(false);
        if (index < minionSO._dialogueList.Count -1 && minionSO._dialogueList[index].type == DialogueLine.DialogueType.Dialogue || index < minionSO._dialogueList.Count -1 && minionSO._dialogueList[index].type == DialogueLine.DialogueType.Dialogue )
        {
            index = minionSO._dialogueList[index].nextLineIndex;
            imageVisage.sprite = minionSO.spriteVisage[minionSO._dialogueList[index].faceIdx];
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        switch (minionSO._dialogueList[index].type)
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
                __choiceidx[i] = minionSO._dialogueList[index].ChoiceIdx[i];
                _ButtonInteraction[i].gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = minionSO._dialogueList[__choiceidx[i]].text;
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
            index = minionSO._dialogueList[__choiceidx[ChoiceParameter]].nextLineIndex;
            textDisplay.text = "";
            StartCoroutine(Type());
            for (int i = 0; i < _ButtonInteraction.Count ; i++)
            {
                _ButtonInteraction[i].SetActive(false);
            }
            continueButton.SetActive(false);
        }
            
    }
    public Minion()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        minionInformation.SetActive(true);
        Destroy(gameObject);
    }
    
    public void VnMode()
    {
        
    }
}
