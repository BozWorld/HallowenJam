using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : LevelEntity
{
    [SerializeField]
    private Trigger trigger;

    public Trap()
    {
        canGoThrough = false;
    }

    private void Update()
    {
        canGoThrough = trigger.isTrigger;
    }
}
