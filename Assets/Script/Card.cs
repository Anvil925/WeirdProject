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
        frontImage.sprite = Resources.Load<Sprite>($"Images/GameCard/card{idx}");
    }

    public void OpenCard()  
    {
        if (!GameManager.Instance.isCanOpen) return;

        if (GameManager.Instance.firstTry == null)
        {
            GameManager.Instance.firstTry = this;
            Debug.Log(GameManager.Instance.firstTry.name.ToString());
        }
        else 
        {
            GameManager.Instance.secondTry = this;
            if(GameManager.Instance.firstTry != GameManager.Instance.secondTry)
            {
                Debug.Log(GameManager.Instance.secondTry.name.ToString());
                GameManager.Instance.isCanOpen = false;
                GameManager.Instance.Matched();
            }
            else
                GameManager.Instance.secondTry = null;
        }
        audioSource.PlayOneShot(clip);


        anim.SetBool("isOpen", true);
        //front.SetActive(true);
        //back.SetActive(false);
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
        Invoke("CloseCardInvoke", 1.0f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        //front.SetActive(false);
        //back.SetActive(true);
        GameManager.Instance.isCanOpen = true;

    }
}
