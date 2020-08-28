using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BeamEndSwap : MonoBehaviour
{
    public enum Direction { VERTICAL, HORIZONTALRIGHT, HORIZONATALLEFT };
    public Direction facing;

    public GameObject vertBeam;
    public GameObject horBeamRight;
    public GameObject horBeamLeft; 

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            switch (facing)
            {
                case Direction.VERTICAL:
                    vertBeam.SetActive(true);
                    horBeamLeft.SetActive(false);
                    horBeamRight.SetActive(false); 
                    break;
                case Direction.HORIZONATALLEFT:
                    vertBeam.SetActive(false);
                    horBeamLeft.SetActive(true);
                    horBeamRight.SetActive(false);
                    break;
                case Direction.HORIZONTALRIGHT:
                    vertBeam.SetActive(false);
                    horBeamLeft.SetActive(false);
                    horBeamRight.SetActive(true);
                    break; 
            }
        }
    }
}
