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
        saveLevel = 2;
        PlayerPrefs.SetInt("LoadLv", saveLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");
    }
    public void Choice3Lv()
    //3lv
    {
        saveLevel = 3;
        PlayerPrefs.SetInt("LoadLv", saveLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");
    }
    public void BackScene()
    {
        SceneManager.LoadScene("OpenScene");
    }
}
