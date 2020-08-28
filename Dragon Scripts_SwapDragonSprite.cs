using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class SwapDragonSprite : MonoBehaviour
{
    public enum Direction { DOWN, LEFT, RIGHT };
    public Direction facing;

    public Sprite downOnSprite;
    public Sprite downOffSprite; 
    public Sprite leftOnSprite;
    public Sprite leftOffSprite; 
    public Sprite rightOnSprite;
    public Sprite rightOffSprite;

    private GameObject button; 
    public bool buttonState;
    public SpriteRenderer dragonRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.FindGameObjectWithTag("EButton");
        dragonRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonState = button.GetComponent<EButtonController>().buttonTouched;
        switch (facing)
        {
            case Direction.DOWN:
                // if the button is not being touched, then the beam should be turned on 
                if (!buttonState)
                {
                    dragonRenderer.sprite = downOnSprite;
                }
                else
                {
                    dragonRenderer.sprite = downOffSprite;
                }
                break;
            case Direction.LEFT:
                if (!buttonState)
                {
                    dragonRenderer.sprite = leftOnSprite;
                }
                else
                {
                    dragonRenderer.sprite = leftOffSprite;
                }
                break;
            case Direction.RIGHT:
                if (!buttonState)
                {
                    dragonRenderer.sprite = rightOnSprite;
                }
                else
                {
                    dragonRenderer.sprite = rightOffSprite;
                }
                break;

        }
    }
}
