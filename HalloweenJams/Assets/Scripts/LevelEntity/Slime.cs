using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : LevelEntity
{
    public Slime()
    {
        interactOnSameSquare = true;
    }

    public override void Interact(Player player)
    {
        if (player.canChangeMinionCount1 && player.canChangeMinionCount2 && !player.IsEntityMoving())
        {
            player.minionsCount -= 1;
            player.canChangeMinionCount1 = false;
            player.canChangeMinionCount2 = false;
        }
    }
}