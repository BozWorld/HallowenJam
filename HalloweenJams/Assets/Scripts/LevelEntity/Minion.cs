using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : LevelEntity
{
    public GameObject[] minionScript;
    public int MinionIdx;   
    public string MinionName;
    void Start()
    {
       
    }
    public Minion()
    {
        canGoThrough = false;
    }

    public override void Interact(Player player)
    {
        player.minionsCount += 1;
        Destroy(gameObject);
    }
}
