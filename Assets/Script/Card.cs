using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;

    public GameObject front;
    public GameObject back;

    public Animator anim;


    public SpriteRenderer frontImage;

    public int idx = 0;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Setting(int num)
    {
        idx = num;
        //frontImage.sprite = R
    }

    public void OpenSceneSetting(int num, string path)
    {
        if (frontImage == null)
        {
            Debug.LogError("FrontImageê°€ Scene???†ìŠµ?ˆë‹¤!");
        }

        string file_path = $"{path}{num}";
        Debug.Log(file_path);
        frontImage.sprite = Resources.Load<Sprite>(file_path);
    }

    public void OpenCard()  
    {
        audioSource.PlayOneShot(clip);

    }
}
