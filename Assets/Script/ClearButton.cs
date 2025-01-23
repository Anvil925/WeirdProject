using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearButton : MonoBehaviour
{
    public void Clear()
    {
        Debug.Log("StartBtn");
        SceneManager.LoadScene("ClearScene");
    }
}