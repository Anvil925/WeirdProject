using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    int toplevel = PlayerPrefs.GetInt("PlayerLv");

    public void Start()
    {
       

    }

    // Start is called before the first frame update
    public void Choice2Lv()
        //2lv
        //���νſ��� ���� Ÿ�̸� 3�� ���� �����ϱ�
    {
        if(toplevel == 2)
        {

        }
    }
    public void Choice3Lv()
        //3lv
        //���νſ��� ���� Ÿ�̸� 1�� ���� �����ϱ�
    {
        if (toplevel == 3)
        {

        }
    }

    public void BackOpenS()
    {
        SceneManager.LoadScene("OpenScene");
        
    }
}
