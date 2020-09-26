using System.Collections.Generic;
using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    [SerializeField] private int _currentIndex = 0;
    [SerializeField] private List<DialogueLine> _dialogueList = new List<DialogueLine>();

    public void HandleDialogue()
    {
        switch (_dialogueList[_currentIndex].type)
        {
            case DialogueLine.DialogueType.Dialogue:
                //Ecrit le text
                break;
            case DialogueLine.DialogueType.Choice:
                //Ecrit le text
                //affiche le choix
                break;
            default:
                break;
        }
    }

    public void GoToIndex(int index)
    {
        if (index >= 0 || index < _dialogueList.Count)
            _currentIndex = index;
    }
}
