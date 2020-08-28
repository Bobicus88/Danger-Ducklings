using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Deliverable : MonoBehaviour, IDynamicObject
{
    public GameObject[] ducks; 
    public GameWon gameWonScript;
    public bool active; 

    /// <summary>
    /// Turns on all the collectibles in the beginning, finds the total number of collectibles
    /// </summary>
    void Start() {
        active = true; 
        gameObject.SetActive(active); 
        ducks = GameObject.FindGameObjectsWithTag("Duck"); 
        gameWonScript = GameObject.FindGameObjectWithTag("WinManager").GetComponent<GameWon>(); 
        // set the total collectibles of gameWon to be the total number of collectibles in the scene
        gameWonScript.totalCollectibles++; 
    }

    /// <summary>
    /// Behavior for when the duck collides with a collectible
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Duck")) 
        {
            // increment the collectibleNum variable of the gameWonScript every time a collectible is destroyed
            gameWonScript.collectibleNum++; 
            active = false; 
            gameObject.SetActive(active); 
        }
    }

    /// <summary>
    /// Adjusts the collectible's state (on/off) based on the specified state
    /// </summary>
    /// <param name="objectState">State of the collectibles</param>
    public void SetState(ObjectState objectState) 
    {
        CollectibleInfo infoState = (CollectibleInfo) objectState; 
        active = infoState.active; 
        gameObject.SetActive(active); 
        gameWonScript.collectibleNum = infoState.collectibleNum; 
    }

    /// <summary>
    /// Returns a state of the collectible's on/off property
    /// </summary>
    /// <returns></returns>
    public ObjectState GetState() {
        CollectibleInfo infoState = new CollectibleInfo(); 
        infoState.active = active; 
        infoState.collectibleNum = gameWonScript.collectibleNum; 
        return infoState; 
    }
}

/// <summary>
/// Collectible Info class to store variables about the states of the "Collectible" dynamic objects
/// </summary>
public class CollectibleInfo : ObjectState
{
    public bool active; 
    public int collectibleNum; 
}



