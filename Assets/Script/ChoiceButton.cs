using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public int toplevel;

    public void Awake()
    {
        toplevel = PlayerPrefs.GetInt("PlayerLv");
    }


    public void Choice2Lv()
        //2lv
        //���νſ��� ���� Ÿ�̸� 3�� ���� �����ϱ�
    {
        if(toplevel >= 2)
        {
            SceneManager.LoadScene("MainScene");
            GameManager.Instance.Level2();
        }
    }
    public void Choice3Lv()
    //3lv
    //���νſ��� ���� Ÿ�̸� 1�� ���� �����ϱ�
    {
        if (toplevel == 3)
        {
            SceneManager.LoadScene("MainScene");
            GameManager.Instance.time = 60.0f;
        }
    }

    public void BackOpenS()
    {
        SceneManager.LoadScene("OpenScene");
        
    }
}
