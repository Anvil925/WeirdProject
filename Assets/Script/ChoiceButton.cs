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
        Debug.Log("Save Level: " + saveLevel); // 현재 저장된 레벨을 확인
        if (saveLevel >= 2)
        {
            Debug.Log("Level 2 Unlocked!"); // 조건이 충족되었는지 확인
            PlayerPrefs.DeleteKey("Loadlv2");
            PlayerPrefs.SetString("Loadlv2", "2");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main2Scene");
        }
        else
        {
            Debug.Log("Level 2 is locked!"); // 조건이 충족되지 않은 경우
        }

    }
    public void Choice3Lv()
    //3lv
    {
        Debug.Log("Save Level: " + saveLevel); // 현재 저장된 레벨을 확인
        if (saveLevel >= 3)
        {
            Debug.Log("Level 3 Unlocked!"); // 조건이 충족되었는지 확인
            PlayerPrefs.DeleteKey("Loadlv3");
            PlayerPrefs.SetString("Loadlv3", "3");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Main3Scene");
        }
        else
        {
            Debug.Log("Level 3 is locked!"); // 조건이 충족되지 않은 경우
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
