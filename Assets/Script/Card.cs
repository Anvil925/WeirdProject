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


    public void OpenCard()  //임의로 작성한 함수라 수정하셔도 괜찮습니다!
    {
        audioSource.PlayOneShot(clip);
    }

    public void Setting(int num)
    {
        idx = num;
        //frontImage.sprite = R

    }

    public void OpenSceneSetting(int num)
    {
        
    }
}
