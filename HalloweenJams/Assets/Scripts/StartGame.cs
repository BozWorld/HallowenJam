using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private LevelMemory cameraPosition;
    [SerializeField]
    private LevelMemory playerPosition;

    private void Start()
    {
        transform.position = playerPosition.positions[playerPosition.index];
        cam.position = new Vector3(cameraPosition.positions[cameraPosition.index].x, cameraPosition.positions[cameraPosition.index].y, cam.position.z);
    }
}
