using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EButtonController : MonoBehaviour
{
    public GameObject[] currents;
    public Sprite downButton;
    public Sprite upButton;
    private SpriteRenderer buttonRender;
    public bool buttonTouched; 


    void Start()
    {
        // turn on electrical current sound effect
        AudioManager.instance.SetLoop(true, "Electrical Current");
        AudioManager.instance.Play("Electrical Current");

        // At first, nothing should be on the button
        buttonTouched = false; 

        currents = GameObject.FindGameObjectsWithTag("Current");
        buttonRender = gameObject.GetComponent<SpriteRenderer>();
    }

    public void pressButton()
    {
        for (int i = 0; i < currents.Length; i++)
        {
            currents[i].SetActive(false);
        }
    }

    ///<summary>
    /// turn off all currents if at least one duck steps on a button
    /// stop electrical current sound effect
    ///</summary>
    private void OnTriggerStay2D(Collider2D collision)
    {
        AudioManager.instance.FindSound("Electrical Current").source.Stop(); 
        AudioManager.instance.SetLoop(false, "Electrical Current");

        buttonRender.sprite = downButton;
        buttonTouched = true; 

        if (collision.gameObject.CompareTag("Duck"))
        {
            for (int i = 0; i < currents.Length; i++)
            {
                currents[i].SetActive(false);
            }
        }
    }

    // Sound effect for when a duck steps on a button
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioManager.instance.Play("ButtonOn"); 
    }


    ///<summary>
    /// turn on the currents when all ducks step off all buttons
    /// turn on electrical current sound effect
    ///</summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        AudioManager.instance.SetLoop(true, "Electrical Current");
        AudioManager.instance.Play("Electrical Current");
        AudioManager.instance.Play("ButtonOff"); 

        buttonRender.sprite = upButton;
        buttonTouched = false; 

        if (collision.gameObject.CompareTag("Duck"))
        {
            for (int i = 0; i < currents.Length; i++)
            {
                currents[i].SetActive(true);
            }
        }
    }

    ///<summary>
    /// stops the looping of the electric current sound effect once
    /// the ducks win the level/the player is no longer playing the level
    ///</summary>
    private void OnDestroy()
    {
        if (AudioManager.instance.FindSound("Electrical Current") != null)
        {
            AudioManager.instance.FindSound("Electrical Current").source.Stop();
            AudioManager.instance.SetLoop(false, "Electrical Current");
            buttonTouched = false;
        }
    }

}



