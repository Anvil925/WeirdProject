using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    // �����ϱ� ��ư
    public void Btn_Start()
    {
        Debug.Log("StartBtn");
        SceneManager.LoadScene("MainScene");
    }
}
