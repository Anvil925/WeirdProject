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


    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;

    public float time = 300.0f;

    float endtime = 0f;


    int level = 3;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N1");

        if(time <= endtime)
        {
            Time.timeScale = 0f;
            GameLvSave();
        }
    }
    
    public void GameLvSave()
    {
        PlayerPrefs.SetInt("PlayerLv", level);
        PlayerPrefs.Save();
    }

    public void Matched()
    {

    }
}
