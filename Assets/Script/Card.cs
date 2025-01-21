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


    public void OpenCard(bool sound)  //임의로 작성한 함수라 수정하셔도 괜찮습니다!
    {
        if (sound)
        {
            audioSource.PlayOneShot(clip);
        }
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
            Debug.LogError("FrontImage가 Scene에 없습니다!");
        }

        string file_path = $"{path}/{num}";
        Debug.Log(file_path);
        frontImage.sprite = Resources.Load<Sprite>(file_path);
    }
}
