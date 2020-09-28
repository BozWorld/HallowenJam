using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject[] ChoiceButton;
    public GameObject characterHead;
    public float AnimationTime;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(characterHead, 1329f, AnimationTime).setLoopPingPong();
        LeanTween.rotateZ(characterHead,-15.668f,AnimationTime).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
