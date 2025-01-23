using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main1Scene");
    }

    public void HiddeRetry()
    {
        SceneManager.LoadScene("HiddenScene");
    }
}
