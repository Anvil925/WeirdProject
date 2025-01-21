using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;

    public GameObject endTxt;

    public AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;
    public int level = 1;

    float time;
    float endtime = 0f;

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

        if (level == 1)
        {
            time = 300.0f;
        }
        else if(level == 2) 
        {
            time = 180.0f;
        }
        else if(level == 3)
        {
            time = 60.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");


        if (time >= endtime)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    

}
