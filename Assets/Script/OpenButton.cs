using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenButton : MonoBehaviour
{
    public void Open()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("OpenScene");
    }

    public void ClearScene()
    {
        SceneManager.LoadScene("ClearScene");
    }
}
