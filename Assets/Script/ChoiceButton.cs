using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Choice()
    {
        
        if (PlayerPrefs.GetFloat("toplevel") <= 2)
            //2�ܰ�
        {
            SceneManager.LoadScene("MainScene");

        }
        else if (PlayerPrefs.GetFloat("toplevel") <= 3)
            //3�ܰ�
        {
            SceneManager.LoadScene("MainScene");
            // ���� �� ���� �ð� 1������ ����

        }

    }
}
