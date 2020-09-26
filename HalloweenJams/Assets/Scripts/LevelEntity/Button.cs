using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : LevelEntity
{
    [SerializeField]
    private int minionsNeeded = 0;
    [SerializeField]
    private Trigger trigger;

    public Button()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        if (player.minionsCount >= minionsNeeded && !trigger.isTrigger)
        {
            trigger.isTrigger = true;
            player.minionsCount -= minionsNeeded;
        }
        else if (trigger.isTrigger)
        {
            player.minionsCount += minionsNeeded;
            trigger.isTrigger = false;
        }
    }

    private void OnApplicationQuit()
    {
        trigger.isTrigger = false;
    }
}
