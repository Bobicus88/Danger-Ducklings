using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SwapCordSprite : MonoBehaviour
{ 
    public enum Direction { VERTICAL, HORIZONTAL};
    public Direction facing;

    public Sprite horCordSprite;
    public Sprite vertCordSprite; 

    public GameObject vertElectric;
    public GameObject horElectric; 

    public SpriteRenderer cordRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cordRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only switch the sprites when you're not in play mode (otberwise, it messes up the "turning off electricity" behavior) 
        if (!Application.isPlaying)
        {
            switch (facing)
            {
                case Direction.HORIZONTAL:
                    cordRenderer.sprite = horCordSprite;
                    vertElectric.SetActive(false);
                    horElectric.SetActive(true);
                    break;
                case Direction.VERTICAL:
                    cordRenderer.sprite = vertCordSprite;
                    vertElectric.SetActive(true);
                    horElectric.SetActive(false);
                    break;
            }
        }
    }
}
