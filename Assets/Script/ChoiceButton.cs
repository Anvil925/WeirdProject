using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceButton : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    public void Choice2Lv()
        //2lv
        //메인신에서 시작 타이머 3분 으로 변경하기
    {

    }
    public void Choice3Lv()
        //3lv
        //메인신에서 시작 타이머 1분 으로 변경하기
    {

    }

    public void BackOpenS()
    {
        SceneManager.LoadScene("OpenScene");
        anim.SetBool("isUse", true);
    }
}
