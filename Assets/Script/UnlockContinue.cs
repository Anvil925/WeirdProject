using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockContinue : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject continueBtn;
    public GameObject questionBtn;
    void Start()
    {
        Debug.Log(PlayerPrefs.HasKey("Main1Scene"));
        Debug.Log(PlayerPrefs.HasKey("Main3Scene"));

        if (PlayerPrefs.HasKey("Main1Scene"))
            continueBtn.GetComponent<Button>().interactable = true;

        if(PlayerPrefs.HasKey("Main3Scene"))
            questionBtn.GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
