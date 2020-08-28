using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoStrikesHazardController : Hazard
{

    public GameObject[] ducks;
    public DuckMove duckMoveScript;
    public int touchCount;

    /// <summary>
    /// reset touchCount, set both ducks active and enable their movements
    ///</summary>
    void Start()
    {
        touchCount = 0;
        ducks = GameObject.FindGameObjectsWithTag("Duck");
        for (int i = 0; i < ducks.Length; i++)
        {
            ducks[i].GetComponent<SpriteRenderer>().enabled = true;
        }
        duckMoveScript = GameObject.FindGameObjectWithTag("Movement").GetComponent<DuckMove>();
        duckMoveScript.enabled = true;
    }

    /// <summary>
    /// Make the duck that collided with the hazard twice disappear, disable the movement of the other duck
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Duck"))
        {
            touchCount++;
            if (touchCount > 1)
            {
                KillPlayer(collision.gameObject);
            }
        }
    }

}
