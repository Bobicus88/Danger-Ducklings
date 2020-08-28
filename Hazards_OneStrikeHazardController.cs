using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneStrikeHazardController : Hazard
{
    private GameObject[] ducks;

    /// <summary>
    /// set both ducks active and enable their movements
    /// </summary>
    void Start()
    {
        ducks = GameObject.FindGameObjectsWithTag("Duck");
        for (int i = 0; i < ducks.Length; i++)
        {
            ducks[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
    }

    /// <summary>
    /// Make the duck that collided with the hazard once disappear, disable the movement of the other duck 
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Duck"))
        {
            KillPlayer(collision.gameObject);
        }
    }
}
