using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        
    }
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = this.clip;
        audioSource.Play();
    }
    void Update()
    {
        
    }
}
