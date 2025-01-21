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
        frontImage.sprite = Resources.Load<Sprite>($"Images/GameCard/card{idx}");
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

    public void OpenCard()  
    {
        if (!GameManager.Instance.isCanOpen) return;

        if (GameManager.Instance.firstTry == null)
            GameManager.Instance.firstTry = this;
        else
        {
            GameManager.Instance.secondTry = this;
            GameManager.Instance.isCanOpen = false;
            GameManager.Instance.Matched();
        }
        audioSource.PlayOneShot(clip);


        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
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
        front.SetActive(false);
        back.SetActive(true);
        GameManager.Instance.isCanOpen = true;

    }
}
