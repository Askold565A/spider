﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{

    private Transform player;

    public float minX, maxX;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            // temp.y = player.position.y + 3f;

            if (temp.x < minX)
            {
                temp.x = minX;
            }

            if (temp.x > maxX)
            {
                temp.x = maxX;
            }

            transform.position = temp;
        }
    }
}
