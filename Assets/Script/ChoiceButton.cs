using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceButton : MonoBehaviour
{

    public int saveLevel;

    public void Start()
    {
        saveLevel = PlayerPrefs.GetInt("GameLv");

    }

    public void Choice2Lv()
    //2lv
    {
        if (saveLevel >= 2)
        {
            PlayerPrefs.SetString("Loadlv2", "2");
            PlayerPrefs.SetInt("LoadLv", saveLevel);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main2Scene");
        }
    }
    public void Choice3Lv()
    //3lv
    {
        if (saveLevel >= 3)
        {
            PlayerPrefs.SetString("Loadlv3", "3");
            PlayerPrefs.SetInt("LoadLv", saveLevel);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main3Scene");
        }
    }
    public void BackScene()
    {
        SceneManager.LoadScene("OpenScene");
    }
}
