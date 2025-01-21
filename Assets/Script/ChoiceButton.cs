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
        //메인신에서 시작 타이머 3분 으로 변경하기
    {
        if(toplevel >= 2)
        {
            SceneManager.LoadScene("MainScene");
            GameManager.Instance.Level2();
        }
    }
    public void Choice3Lv()
    //3lv
    //메인신에서 시작 타이머 1분 으로 변경하기
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
