using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBtn : MonoBehaviour
{
    // 이어하기 버튼
    public void Btn_Continue()
    {
        Debug.Log("ContinueBtn");
        SceneManager.LoadScene("ChoiceScene");
    }
}
