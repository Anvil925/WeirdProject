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
        //첫번째 firstTry에 값이 들어오고 바로 다음 눌렀을때 firstTry에 또 들어오는 것을 해소
        //두번재부터는 isCanOpen 이 true기 때문에 아래 return에 걸리지 않고 firstTryif에도 걸리지 않고 else문으로 가게됨.
        if (!GameManager.Instance.isCanOpen) return;
        if (GameManager.Instance.firstTry == null)
        {
            GameManager.Instance.firstTry = this;
            audioSource.PlayOneShot(clip);
            GameManager.Instance.firstTry.anim.SetBool("isOpen", true);
        }
        else if(GameManager.Instance.secondTry == null) //두번째 카드가 비었을때
        {
            GameManager.Instance.secondTry = this; // 널값인 두번째 카드를 현재 카드로 만들어줌
            if(GameManager.Instance.firstTry != GameManager.Instance.secondTry) // 첫번째카드와 두번째 카드가 같지않을때 
            {
                GameManager.Instance.secondTry.anim.SetBool("isOpen", true); //두번째 카드의 앞면을 공개
                GameManager.Instance.Matched(); // 두 카드를 삭제할지 다시 뒷면으로 할지 비교
                GameManager.Instance.isCanOpen = false; 
                audioSource.PlayOneShot(clip);
            }
            else
                GameManager.Instance.secondTry = null;
        }
        //audioSource.PlayOneShot(clip);
        //
        //
        //anim.SetBool("isOpen", true);
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
