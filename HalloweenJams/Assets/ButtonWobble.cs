using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ButtonWobble : MonoBehaviour
{
    public Image imageText;
    public bool useSpriteMesh = true;
    Mesh  _Mesh;
    // Start is called before the first frame update
    void Start()
    {
        imageText = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
