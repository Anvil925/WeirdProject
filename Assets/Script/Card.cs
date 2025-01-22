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
        //Ã¹¹øÂ° firstTry¿¡ °ªÀÌ µé¾î¿À°í ¹Ù·Î ´ÙÀ½ ´­·¶À»¶§ firstTry¿¡ ¶Ç µé¾î¿À´Â °ÍÀ» ÇØ¼Ò
        //µÎ¹øÀçºÎÅÍ´Â isCanOpen ÀÌ true±â ¶§¹®¿¡ ¾Æ·¡ return¿¡ °É¸®Áö ¾Ê°í firstTryif¿¡µµ °É¸®Áö ¾Ê°í else¹®À¸·Î °¡°ÔµÊ.
        if (!GameManager.Instance.isCanOpen) return;
        if (GameManager.Instance.firstTry == null)
        {
            GameManager.Instance.firstTry = this;
            audioSource.PlayOneShot(clip);
            GameManager.Instance.firstTry.anim.SetBool("isOpen", true);
        }
        else if(GameManager.Instance.secondTry == null) //µÎ¹øÂ° Ä«µå°¡ ºñ¾úÀ»¶§
        {
            GameManager.Instance.secondTry = this; // ³Î°ªÀÎ µÎ¹øÂ° Ä«µå¸¦ ÇöÀç Ä«µå·Î ¸¸µé¾îÁÜ
            if(GameManager.Instance.firstTry != GameManager.Instance.secondTry) // Ã¹¹øÂ°Ä«µå¿Í µÎ¹øÂ° Ä«µå°¡ °°Áö¾ÊÀ»¶§ 
            {
                GameManager.Instance.secondTry.anim.SetBool("isOpen", true); //µÎ¹øÂ° Ä«µåÀÇ ¾Õ¸éÀ» °ø°³
                GameManager.Instance.Matched(); // µÎ Ä«µå¸¦ »èÁ¦ÇÒÁö ´Ù½Ã µÞ¸éÀ¸·Î ÇÒÁö ºñ±³
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
