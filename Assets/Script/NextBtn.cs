using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBtn : MonoBehaviour
{



    public void Start()
    {

    }
    public void Next2Lv()
    {
            PlayerPrefs.SetString("Loadlv2", "2");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main2Scene");
    }

    public void Next3Lv()
    {
            PlayerPrefs.SetString("Loadlv3", "3");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main3Scene");

    }
}
