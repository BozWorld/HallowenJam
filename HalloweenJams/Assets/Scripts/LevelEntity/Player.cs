﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableEntity
{
    public bool canChangeMinionCount1 = true;
    public bool canChangeMinionCount2 = true;

    public bool gotTorch = false;
    public bool canPlayerInteract = true;

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
            if (direction.x == -1)
            {
                GetComponent<Animator>().SetBool("ReverseSide",true);
            }
            if (direction.x == 1)
            {
                GetComponent<Animator>().SetBool("GoSide",true);
            }
            if (direction.y == 1)
            {
                GetComponent<Animator>().SetBool("ReverseFront",true);
            }
            if (direction.y == -1)
            {
                GetComponent<Animator>().SetBool("GoFront",true);
            }
        }
    }

    override public void MoveEntity(Vector2 axis, bool rotateOnly)
    {
        if (canPlayerInteract)
        {
            if (!rotateOnly)
            {
                target = new Vector2(Mathf.Round(transform.position.x + axis.x * movementValues.squareSize), Mathf.Round(transform.position.y + axis.y * movementValues.squareSize));
                isMoving = true;
            }
            direction = axis;
        }
    }
    
    public void EndingFrontAnimation()
    {
        GetComponent<Animator>().SetBool("ReverseSide",true);
        GetComponent<Animator>().SetBool("GoSide",true);
        GetComponent<Animator>().SetBool("ReverseFront",true);
        GetComponent<Animator>().SetBool("GoFront",true);
    }
}
