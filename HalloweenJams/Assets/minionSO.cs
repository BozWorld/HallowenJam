using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "minionSO")]
public class minionSO : ScriptableObject
{
    //MinionInFormation
    public string characterName;
    public Sprite descriptionSprite; 
    public Sprite[] spriteVisage;
    public Sprite characterSprite;
    [SerializeField] private List<DialogueLine> _dialogueList = new List<DialogueLine>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
