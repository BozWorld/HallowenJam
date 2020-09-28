using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class vertextWobble : MonoBehaviour
{
    public TMP_Text textMesh;
    Mesh _mesh;
    public AnimationCurve curves;
    Vector3[] vertices;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.ForceMeshUpdate();
        _mesh  = textMesh.mesh;
        vertices = _mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = Wobble(Time.time + i );
            vertices[i] = vertices[i] + offset;
        }
        _mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(_mesh);
    }
    Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time*3.3f), Mathf.Cos(time*2.5f));
    }
}
