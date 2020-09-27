using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : LevelEntity
{
    [SerializeField]
    private LevelMemory startPositions;
    [SerializeField]
    private LevelMemory cameraPosition;
    [SerializeField]
    MovableEntity cam;
    [SerializeField]
    private Turns turns;

    public EndLevel()
    {
        interactOnSameSquare = true;
    }

    Vector2 GetAxis(Vector2 startPosition, Vector2 targetPosition, float squareSize)
    {
        Vector2 distance = new Vector2(targetPosition.x - startPosition.x, targetPosition.y - startPosition.y);

        return new Vector2(distance.x / squareSize, distance.y / squareSize);
    }

    public override void Interact(Player player)
    {
        if (!player.IsEntityMoving() && !cam.IsEntityMoving())
        {
            startPositions.index += 1;
            cameraPosition.index += 1;

            Vector2 playerAxis = GetAxis(player.GetPosition(), startPositions.positions[startPositions.index], player.GetSquareSize());
            Vector2 cameraAxis = GetAxis(cam.GetPosition(), cameraPosition.positions[cameraPosition.index], player.GetSquareSize());

            player.MoveEntity(playerAxis, false);
            cam.MoveEntity(cameraAxis, false);

            player.gotTorch = false;
            player.minionsCount = 0;
            turns.turns = 0;
        }
    }
}
