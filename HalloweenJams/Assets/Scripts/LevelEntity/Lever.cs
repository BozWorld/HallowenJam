using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : LevelEntity
{
    [SerializeField]
    private int minionsNeeded = 0;
    [SerializeField]
    private Trigger trigger;

    public Lever()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        if (player.minionsCount >= minionsNeeded)
            trigger.isTrigger = !trigger.isTrigger;
    }

    private void OnApplicationQuit()
    {
        trigger.isTrigger = false;
    }
}
