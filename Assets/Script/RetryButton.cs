using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Main1Scene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main1Scene");
    }
    public void Main2Scene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main2Scene");
    }
    public void Main3Scene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main3Scene");
    }
    public void HiddenRetry()
    {
        SceneManager.LoadScene("HiddenScene");
    }
}
