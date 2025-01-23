using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void Btn_Start()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("StartBtn");
        SceneManager.LoadScene("Main1Scene");
    }
}
