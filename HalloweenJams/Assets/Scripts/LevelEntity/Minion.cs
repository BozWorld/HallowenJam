using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : LevelEntity
{
    public GameObject minionScript;
    public int minionIdx;  
    public Image minionDescription;
    public string minionName;
    public GameObject minionInformation;
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
    
    public void VnMode()
    {
        minionInformation.SetActive(true);
    }
}
