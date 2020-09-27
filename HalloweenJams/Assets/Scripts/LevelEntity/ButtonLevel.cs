using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevel : LevelEntity
{
    [SerializeField]
    private int minionsNeeded = 0;
    [SerializeField]
    private Trigger trigger;

    public ButtonLevel()
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

    private void OnLevelWasLoaded(int level)
    {
        trigger.isTrigger = false;
    }
}
