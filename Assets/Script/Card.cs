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
            Invoke("Match", 0.6f); // �Ǽ��� ������ ���� �����ϸ� ī�� ���� �� ���� ���ư��� ���̵� �ø� �� ����.
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
