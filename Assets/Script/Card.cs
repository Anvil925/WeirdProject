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
            Debug.LogError("FrontImage가 Scene???�습?�다!");
        }

        string file_path = $"{path}{num}";
        Debug.Log(file_path);
        frontImage.sprite = Resources.Load<Sprite>(file_path);
    }

    public void OpenCard()  
    {
        //ù��° firstTry�� ���� ������ �ٷ� ���� �������� firstTry�� �� ������ ���� �ؼ�
        //�ι�����ʹ� isCanOpen �� true�� ������ �Ʒ� return�� �ɸ��� �ʰ� firstTryif���� �ɸ��� �ʰ� else������ ���Ե�.
        if (!GameManager.Instance.isCanOpen) return;
        if (GameManager.Instance.firstTry == null)
        {
            GameManager.Instance.firstTry = this;
            audioSource.PlayOneShot(clip);
            GameManager.Instance.firstTry.anim.SetBool("isOpen", true);
        }
        else if(GameManager.Instance.secondTry == null) //�ι�° ī�尡 �������
        {
            GameManager.Instance.secondTry = this; // �ΰ��� �ι�° ī�带 ���� ī��� �������
            if(GameManager.Instance.firstTry != GameManager.Instance.secondTry) // ù��°ī��� �ι�° ī�尡 ���������� 
            {
                GameManager.Instance.secondTry.anim.SetBool("isOpen", true); //�ι�° ī���� �ո��� ����
                GameManager.Instance.Matched(); // �� ī�带 �������� �ٽ� �޸����� ���� ��
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
