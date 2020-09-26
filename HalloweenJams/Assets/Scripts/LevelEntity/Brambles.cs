using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brambles : LevelEntity
{
    public Brambles()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        if (player.gotTorch)
            Destroy(gameObject);
    }
}
