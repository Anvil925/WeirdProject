using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        //PlayerPrefs.DeleteAll();
        Scene scene = GetCurrentScene();

        if(scene.name == "Main1Scene")
        {
            SceneManager.LoadScene("Main1Scene");
        }
        else if (scene.name == "Main2Scene")
        {
            SceneManager.LoadScene("Main2Scene");
        }
        else if (scene.name == "Main3Scene")
        {
            SceneManager.LoadScene("Main3Scene");
        }

        
    }

    public void HiddeRetry()
    {
        SceneManager.LoadScene("HiddenScene");
    }
    Scene GetCurrentScene()
    {
        return SceneManager.GetActiveScene();
    }
}
