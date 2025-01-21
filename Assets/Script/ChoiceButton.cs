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
            //2단계
        {
            SceneManager.LoadScene("MainScene");

        }
        else if (PlayerPrefs.GetFloat("toplevel") <= 3)
            //3단계
        {
            SceneManager.LoadScene("MainScene");
            // 메인 씬 남은 시간 1분으로 변경

        }

    }
}
