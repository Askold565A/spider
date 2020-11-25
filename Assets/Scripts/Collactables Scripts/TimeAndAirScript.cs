using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAirScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            if (gameObject.name == "TimerElement")
            {
                GameObject.Find("GameplayController").GetComponent<LevelTimer>().time += 15f;
            }
            else
            {
                GameObject.Find("GameplayController").GetComponent<AirTimer>().air += 15f;
            }
            Destroy(gameObject);
        }
    }

}
