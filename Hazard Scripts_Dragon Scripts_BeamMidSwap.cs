using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BeamMidSwap : MonoBehaviour
{
    public enum Direction { VERTICAL, HORIZONTAL };
    public Direction facing;

    public GameObject vert; 
    public GameObject hor; 

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            switch (facing)
            {
                case Direction.VERTICAL:
                    vert.SetActive(true);
                    hor.SetActive(false); 
                    break;
                case Direction.HORIZONTAL:
                    vert.SetActive(false);
                    hor.SetActive(true); 
                    break;
            }
        }
    }
}
