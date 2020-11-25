using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        if (DoorScript.instance != null)
        {
            DoorScript.instance.collectablesCount++;
        }
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
            Destroy(gameObject);
        {
            DoorScript.instance.DecrementCollectables();
        }
    }
}
