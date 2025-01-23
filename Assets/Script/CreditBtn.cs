using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditBtn : MonoBehaviour
{
    public GameObject Credit;

    // Credit 진입 버튼
    public void Btn_Credit()
    {
        Debug.Log("CreditBtn");
        Credit.SetActive(true);
    }

    // Credit ?�출 버튼
    public void Btn_CreditExit()
    {
        Debug.Log("CreditExitBtn");
        Credit.SetActive(false);
    }
}
