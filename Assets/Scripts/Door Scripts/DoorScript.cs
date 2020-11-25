﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public static DoorScript instance;

    private Animator anim;
    private BoxCollider2D box;

    [HideInInspector]
    public int collectablesCount;

    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    
    public void DecrementCollectables()
    {
        collectablesCount--;

        if (collectablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
 
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
        }
           
    }
}
