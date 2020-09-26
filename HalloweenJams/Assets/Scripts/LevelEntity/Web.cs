using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : LevelEntity
{
    [SerializeField]
    private Turns turns;
    [SerializeField]
    private int maxTurns = 0;

    private int startTurn = 0;
    private bool minion = false;

    public Web()
    {
        interactOnSameSquare = true;
    }

    public override void Interact(Player player)
    {
        if(!minion)
        {
            if (player.canChangeMinionCount1 && player.canChangeMinionCount2)
            {
                player.minionsCount -= 1;
                startTurn = turns.turns;
                minion = true;
                player.canChangeMinionCount1 = false;
                player.canChangeMinionCount2 = false;
            }
        }
        else
        {
            if (player.gotTorch)
            {
                if (minion)
                    player.minionsCount += 1;
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (minion && turns.turns - startTurn == maxTurns)
            minion = false;
    }
}
