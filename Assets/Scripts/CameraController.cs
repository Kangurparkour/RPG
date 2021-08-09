using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player_transform;
    Transform camera_transform;
    public Vector3 offset;

    private void Start()
    {
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        camera_transform = transform;
    }

    private void Update()
    {
        transform.position = player_transform.position + offset;
    }

}
