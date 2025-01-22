using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetPitch(float newPitch)
    {
        audioSource.pitch = newPitch;
    }
}
