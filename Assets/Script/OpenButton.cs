using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenButton : MonoBehaviour
{
    public void Open()
    {
        SceneManager.LoadScene("OpenScene");
    }
}
