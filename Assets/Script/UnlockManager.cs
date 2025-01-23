using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour
{
    public GameObject lv2;
    public GameObject lv3;
   

    private void Start()
    {

        if (PlayerPrefs.HasKey("Main1Scene"))
        {
            lv2.GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.HasKey("Main2Scene"))
        {
            lv3.GetComponent<Button>().interactable = true;
        }
    }

    private void Update()
    {
        
    }
}
