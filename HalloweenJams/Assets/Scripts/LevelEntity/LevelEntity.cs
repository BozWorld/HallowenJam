using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntity : MonoBehaviour
{
    protected bool isMovable = false;
    protected bool canGoThrough = true;
    protected bool interactOnSameSquare = false;
    protected bool interactOnRaycast = false;

    public bool CanGoThrough()
    {
        return canGoThrough;
    }

    public bool InteractOnSameSquare()
    {
        return interactOnSameSquare;
    }

    public bool InteractOnRaycast()
    {
        return interactOnRaycast;
    }

    public bool IsMovable()
    {
        return isMovable;
    }

    public Vector2 GetPosition()
    {
        return (new Vector2(transform.position.x, transform.position.y));
    }

    virtual public void Interact(Player player)
    {
    }
}
