﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraDistOffset = 10;
    private Camera mainCamera;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - cameraDistOffset);
    }
}
