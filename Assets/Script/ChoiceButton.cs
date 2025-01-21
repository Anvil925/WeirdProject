using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    public int toplevel;
    public GameManager gameManager;

    public void Awake()
    {
        toplevel = PlayerPrefs.GetInt("PlayerLv");

    }


    public void Choice2Lv()
        //2lv
        //메인신에서 레벨 2 으로 변경하기
    {
        if(toplevel >= 2)
        {
            SceneManager.LoadScene("MainScene");
            
        }
    }
    public void Choice3Lv()
    //3lv
    //메인신에서 레벨 3 으로 변경하기
    {
        if (toplevel == 3)
        {
            SceneManager.LoadScene("MainScene");
            
        }
    }

    public void BackOpenS()
    {
        SceneManager.LoadScene("OpenScene");
        
    }
}
