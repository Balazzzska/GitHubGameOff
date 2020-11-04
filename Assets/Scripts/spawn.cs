﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class spawn : NetworkBehaviour
{
    public Camera cam;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteEmemy;
    public Sprite spriteMe;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = isLocalPlayer ? spriteMe : spriteEmemy;
        cam.enabled = isLocalPlayer;

    }

    // Update is called once per frame
    void Update()
    {

    }

}
