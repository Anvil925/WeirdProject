using System.Collections;
using System.Collections.Generic;
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


    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;
        audioSource.PlayOneShot(clip);


        front.SetActive(true);
        back.SetActive(false);

        if (GameManager.Instance.firstCard == null)
        {
            GameManager.Instance.firstCard = this;

        }
        else
        {
            GameManager.Instance.secondCard = this;
            GameManager.Instance.Matched();
        }
    }
            public void Setting(int num)
    {
        idx = num;
        

    }

    public void OpenSceneSetting(int num)
    {
        
    }
}
