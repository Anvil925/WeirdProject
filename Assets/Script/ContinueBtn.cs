using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueBtn : MonoBehaviour
{
    // �̾��ϱ� ��ư
    public void Btn_Continue()
    {
        Debug.Log("ContinueBtn");
        SceneManager.LoadScene("ChoiceScene");
    }
}
