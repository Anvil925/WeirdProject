using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBtn : MonoBehaviour
{
    int level;


    public void Start()
    {
        level = PlayerPrefs.GetInt("GameLv");
    }
    public void Next2Lv()
    {
        if (level == 2)
        {
            PlayerPrefs.DeleteKey("Loadlv2");
            PlayerPrefs.SetString("Loadlv2", "2");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main2Scene");
        }
    }

    public void Next3Lv()
    {
        if (level == 3)
        {
            PlayerPrefs.DeleteKey("Loadlv3");
            PlayerPrefs.SetString("Loadlv3", "3");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main2Scene");
        }
    }
}
