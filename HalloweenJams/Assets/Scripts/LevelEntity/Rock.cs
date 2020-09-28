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
        Collider2D[] frontEntity;
        Vector2 direction = player.GetDirection();

        frontEntity = Physics2D.OverlapCircleAll(new Vector2(transform.position.x + player.GetSquareSize() * direction.x, transform.position.y + player.GetSquareSize() * direction.y), 0.5f);

        if (frontEntity.Length == 0)
            MoveEntity(player.GetDirection(), false);
    }
}
