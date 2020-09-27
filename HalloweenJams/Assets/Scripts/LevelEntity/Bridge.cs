using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bridge : LevelEntity
{
    [SerializeField]
    private int maxMinions = 0;

    public Bridge()
    {
        interactOnSameSquare = true;
    }

    public override void Interact(Player player)
    {
        if (player.minionsCount > maxMinions)
            SceneManager.LoadScene("Movement");
    }
}
