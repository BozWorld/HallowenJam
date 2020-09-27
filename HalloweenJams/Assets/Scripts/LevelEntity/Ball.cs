using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MovableEntity
{
    Player playerMemory;
    public Ball()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        playerMemory = player;
        Vector2 direction = player.GetDirection();
        float squareSize = player.GetSquareSize();

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + direction.x * squareSize, transform.position.y + direction.y * squareSize), direction);

        if (hit.collider != null)
        {
            Vector2 destinationPosition = hit.collider.transform.position;

            if (!(destinationPosition.x == (transform.position.x + direction.x * squareSize) && destinationPosition.y == (transform.position.y + direction.y * squareSize)))
            {
                Vector2 distance = new Vector2(destinationPosition.x - transform.position.x, destinationPosition.y - transform.position.y);
                Vector2 axis = new Vector2(distance.x / squareSize - direction.x, distance.y / squareSize - direction.y);

                MoveEntity(axis, false);
            }

            player.canPlayerInteract = false; ;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, movementValues.speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                isMoving = false;
                playerMemory.canPlayerInteract = true;
            }
        }
    }
}
