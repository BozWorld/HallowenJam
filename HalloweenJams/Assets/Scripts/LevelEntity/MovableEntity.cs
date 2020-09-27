using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEntity : LevelEntity
{
    protected Vector2 direction = new Vector2();
    protected Vector3 target;

    protected bool isMoving = false;

    [SerializeField]
    protected MovementValues movementValues;

    public MovableEntity()
    {
        isMovable = true;
    }

    private void Start()
    {
        if (movementValues == null)
            movementValues = new MovementValues();
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, movementValues.speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
                isMoving = false;
        }
    }

    virtual public void MoveEntity(Vector2 axis, bool rotateOnly)
    {
        if (!rotateOnly)
        {
            target = new Vector3(Mathf.Round(transform.position.x + axis.x * movementValues.squareSize), Mathf.Round(transform.position.y + axis.y * movementValues.squareSize), transform.position.z);
            isMoving = true;
        }
        direction = axis;
    }

    public bool IsEntityMoving()
    {
        return isMoving;
    }

    public Vector2 GetDirection()
    {
        return direction;
    }

    public float GetSquareSize()
    {
        return movementValues.squareSize;
    }
}
