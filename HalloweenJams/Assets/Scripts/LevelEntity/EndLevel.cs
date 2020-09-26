using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : LevelEntity
{
    public EndLevel()
    {
        interactOnSameSquare = true;
    }

    public override void Interact(Player player)
    {
        Debug.Log("End of the level");
    }
}
