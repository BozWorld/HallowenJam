using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
//[CreateAssetMenu(fileName = "New dialogue line", menuName = "PNJ/Dialogue line")]
[System.Serializable]
public class DialogueLine
{
    public DialogueType type = DialogueType.Dialogue;
    [Multiline] public string text = "";
    public int nextLineIndex = 0;
    public List<int> ChoiceIdx = new List<int>();
    public enum DialogueType { Dialogue = 0, Choice = 1, End = 2}
}
