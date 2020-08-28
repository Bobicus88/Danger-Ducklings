using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClick : MonoBehaviour
{
    public void PlayUISound()
    {
        AudioManager.instance.Play("UI Click"); 
    }
}
