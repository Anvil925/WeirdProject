using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Choice2Lv()
        //2lv
        //���νſ��� ���� Ÿ�̸� 3�� ���� �����ϱ�
    {

    }
    public void Choice3Lv()
        //3lv
        //���νſ��� ���� Ÿ�̸� 1�� ���� �����ϱ�
    {

    }

    public void BackOpenS()
    {
        SceneManager.LoadScene("OpenScene");
    }
}
