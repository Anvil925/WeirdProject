using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    // 시작하기 버튼
    public void Btn_Start()
    {
        Debug.Log("StartBtn");
        SceneManager.LoadScene("MainScene");
    }
}
