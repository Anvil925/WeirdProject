using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Loadlv2", "2");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main2Scene");
        }

    }
    public void Choice3Lv()
    //3lv
    {
        if (saveLevel >= 3)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Loadlv3", "3");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main3Scene");
        }
    }
    public void HiddenLv()
    {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Loadlvh", "h");
            PlayerPrefs.Save();
            SceneManager.LoadScene("HiddenScene");
    }

    public void SaveDel()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("OpenScene");
    }
    public void BackScene()
    {
        SceneManager.LoadScene("OpenScene");
    }

    public void HiddenScene()
    {
        SceneManager.LoadScene("HiddenScene");
    }


}
