using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement values")]
public class LevelMemory : ScriptableObject
{
    public int index = 0;
    public List<Vector2> positions;
}