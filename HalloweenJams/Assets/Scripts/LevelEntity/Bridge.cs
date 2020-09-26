using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : LevelEntity
{
    [SerializeField]
    private int maxMinions = 0;

    public Bridge()
    {
        interactOnSameSquare = true;
    }

    public override void Interact(Player player)
    {
        if (player.minionsCount > maxMinions)
            Debug.Log("Game over");
    }
}
