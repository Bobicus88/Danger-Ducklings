using UnityEngine;
using UnityEngine.Audio; 

// So that the custom class shows up in the inspector
[System.Serializable]
public class Sound 
{
    public string name; 
    public AudioClip clip; 
    
    [Range(0f, 1f)]
    public float volume; 
    
    [Range(.1f, 3f)]
    public float pitch; 

    // hide this, because it's an attribute we populate automatically in AudioManager
    [HideInInspector]
    public AudioSource source; 

    public bool loop; 
}
