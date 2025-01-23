using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void Btn_Start()
    {
        Debug.Log("StartBtn");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main1Scene");
    }
}
