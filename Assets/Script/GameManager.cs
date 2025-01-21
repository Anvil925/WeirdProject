using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public AudioSource audioSource;
    public AudioClip clip;

    public Text timeTxt;

    float time = 300.0f;
    int level;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
    
    public void GameLvSave()
    {
        PlayerPrefs.SetInt("PlayerLv", level);
        PlayerPrefs.Save();
    }
}
