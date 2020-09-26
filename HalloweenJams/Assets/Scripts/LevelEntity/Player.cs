using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableEntity
{
    public bool canChangeMinionCount1 = true;
    public bool canChangeMinionCount2 = true;

    public int minionsCount = 0;

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, movementValues.speed * Time.deltaTime);
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                isMoving = false;
                canChangeMinionCount1 = true;
            }
        }

        //Debug.Log(minionsCount);
    }
}
