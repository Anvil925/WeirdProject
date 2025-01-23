using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBtn : MonoBehaviour
{
    // ?�어?�기 버튼
    public void Btn_Continue()
    {
        Debug.Log("ContinueBtn");
        SceneManager.LoadScene("ChoiceScene");
    }
}
