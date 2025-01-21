using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
