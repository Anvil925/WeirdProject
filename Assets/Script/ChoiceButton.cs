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

        Debug.Log(saveLevel);
    }

    public void Choice2Lv()
    //2lv
    {
        Debug.Log("Choice2Lv");
        if (saveLevel >= 2)
        {
            PlayerPrefs.DeleteKey("Loadlv2");
            PlayerPrefs.SetString("Loadlv2", "2");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main2Scene");
        }

    }
    public void Choice3Lv()
    //3lv
    {
        Debug.Log("Choice3Lv");
        if (saveLevel >= 3)
        {
            PlayerPrefs.DeleteKey("Loadlv3");
            PlayerPrefs.SetString("Loadlv3", "3");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main3Scene");
        }
    }
    public void HiddenLv()
    {
            PlayerPrefs.DeleteKey("Loadlvh");
            PlayerPrefs.SetString("Loadlvh", "h");
            PlayerPrefs.Save();
            SceneManager.LoadScene("HiddenScene");
    }

    public void SaveDel()
    {
        PlayerPrefs.DeleteAll();
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
