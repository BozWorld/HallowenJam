using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MovableEntity
{
    public Rock()
    {
        canGoThrough = false;
    }

    override public void Interact(Player player)
    {
        MoveEntity(player.GetDirection(), false);
    }
}
