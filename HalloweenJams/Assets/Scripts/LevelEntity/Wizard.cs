using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MovableEntity
{
    [SerializeField]
    private Vector2 wizardDirection = new Vector2();

    private void Start()
    {
        if (movementValues == null)
            movementValues = new MovementValues();

        canGoThrough = false;
        interactOnRaycast = true;
        direction = wizardDirection;
    }

    public override void Interact(Player player)
    {
        //Debug.Log("fe,of");
        if (player.canChangeMinionCount1 && player.canChangeMinionCount2)
        {
            player.minionsCount -= 1;
            player.canChangeMinionCount1 = false;
            player.canChangeMinionCount2 = false;
        }
    }
}