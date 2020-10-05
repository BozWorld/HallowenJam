using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : LevelEntity
{
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
        minionInformation.SetActive(true);
        Destroy(gameObject);
    }
    
    public void VnMode()
    {
        
    }
}
