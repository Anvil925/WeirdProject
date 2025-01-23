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

    public bool Debug_Mode = false;
    public int idx = 0;
    public float LevelValue = 1;
    
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Debug_Mode)
            anim.SetTrigger("isOpen");

    }

    public void Setting(int num)
    {
        idx = num;
        frontImage.sprite = Resources.Load<Sprite>($"Images/GameCard/card{idx}");
    }

    public void OpenCard()  
    {
        if (!GameManager.Instance.isCanOpen) return;
        if (GameManager.Instance.firstTry == null)
        {
            GameManager.Instance.firstTry = this;
            anim.SetTrigger("isOpen");
            audioSource.PlayOneShot(clip, 0.3f);
        }
        else 
        {
            GameManager.Instance.secondTry = this; 
            if (GameManager.Instance.firstTry.name == GameManager.Instance.secondTry.name)
            {
                GameManager.Instance.secondTry = null;
                return;
            }
            anim.SetTrigger("isOpen");

            // 난이도 조절 가능. 카드 뒤집히는 속도
            Invoke("Match", 0.5f / (LevelValue / 2)); 

            GameManager.Instance.isCanOpen = false;
            audioSource.PlayOneShot(clip, 0.3f);
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
        GameManager.Instance.isCanOpen = true;
    }
    public void CloseCard()
    {
        CloseCardInvoke();
    }
    void CloseCardInvoke()
    {
        GameManager.Instance.firstTry = null;
        GameManager.Instance.secondTry = null;
        GameManager.Instance.isCanOpen = true;
    }

    void Match()
    {
        GameManager.Instance.Matched();
    }
}
