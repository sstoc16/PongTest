using UnityEngine;
using UnityEngine.Audio;
using System;

[Serializable]
public class Sound 
{
   [SerializeField] public string name;
    // Start is called before the first frame update
    public AudioClip clip;

   
    [Range(0f, 1f)]
    [SerializeField] public float volume;
    [Range(.1f, 3f)]
    [SerializeField] public float pitch;

    [HideInInspector]
    public AudioSource source;

}
