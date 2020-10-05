using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class Bonjour : MonoBehaviour
{
    public int HpBar;
    public string characterName;
    // Start is called before the first frame update
    void Start()
    {
        nameCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        takeDamage();
        Debug.Log(HpBar);
    }
    public void nameCharacter(){
        Debug.Log(characterName);
    }

    public void takeDamage(){
        if (HpBar >= 0 )
        {
            HpBar -= 1;
        }

        if (HpBar == 0)
        {
            Debug.Log("tu es mort");
        }
    }
}
