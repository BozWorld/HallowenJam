using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : LevelEntity
{
    public Torch()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        player.gotTorch = true;
        Destroy(gameObject);
    }
}
