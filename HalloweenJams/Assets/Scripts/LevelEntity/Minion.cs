using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : LevelEntity
{
    public Minion()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        player.minionsCount += 1;
        GameObject.Destroy(gameObject);
    }
}
