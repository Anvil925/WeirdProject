using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioManager audioManager;
    public AudioSource audioSource;
    public AudioClip matchClip;
    public AudioClip failClip;
    public AudioClip successClip;

    public Card firstTry;
    public Card secondTry;

    public Text timeTxt;
    public Text CurrentTimeTxt;
    public Text BestTimeTxt;

    public Animator timeAnim;

    public GameObject endTxt;
    public GameObject Result;
    public GameObject FailMsg;
    public GameObject CrealMSg;
    public GameObject Achievements;
    public SceneManager sceneManager;
    public int cardCount = 0;
    public bool isCanOpen = true;
    private float startTime;  
    private float elapsedTime; 
    private float bestTime;   
    private bool pitchChanged = false;

    private string[] sceneName = new string[3];
    

    float time = 0.0f;
    float timeLimit = 0.0f;
    float endtime = 0f;

    int level = 1;
    int toplevel;

    int saveLevel;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        isCanOpen = true;

        string lv2 = PlayerPrefs.GetString("Loadlv2");
        string lv3 = PlayerPrefs.GetString("Loadlv3");
        string hiddenLv = PlayerPrefs.GetString("Loadlvh");
        bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        if (lv2 == "2")
        {
            level = 2;
            saveLevel = PlayerPrefs.GetInt("LoadLv");
        }
        else if (lv3 == "3")
        {
            level = 3;
            saveLevel = PlayerPrefs.GetInt("LoadLv");
        }
        else if (hiddenLv == "h")
        {
            level = 4;
        }

        startTime = Time.time;
        if (level == 1)
        {
            timeLimit = 300.0f;
        }
        else if (level == 2)
        {
            timeLimit = 180.0f;
        }
        else if (level == 3)
        {
            timeLimit = 60.0f;
        }
        else
        {
            timeLimit = 90.0f;
        }
        time = timeLimit;
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (Time.timeScale != 0f)
            time -= Time.deltaTime;
        time = Mathf.Max(time, 0.0f);
        timeTxt.text = time.ToString("N1");


        
        if ((timeLimit / 3) >= time)
        {
            timeAnim.SetBool("isTimeLimit", true);
            if (time <= endtime)
            {
                Time.timeScale = 0f;
                if (level >= toplevel)
                {
                    if (saveLevel <= toplevel)
                    {
                        saveLevel = toplevel;
                        GameLvSave();
                    }
                }
            }
        }
        
        if (time <= (timeLimit / 3) && !pitchChanged)
        {
            StartCoroutine(GraduallyIncreasePitch(1.5f, 3.0f));
            pitchChanged = true;
        }
        
        if (time <= endtime)
        {
            Time.timeScale = 0f;
            Result.SetActive(true);
            if (cardCount > 0)
            {  
                audioSource.PlayOneShot(failClip, 0.05f);
                FailMsg.SetActive(true);
            }
            
            if (level <= toplevel)
            {
                if (saveLevel <= toplevel)
                {
                    saveLevel = toplevel;
                    GameLvSave();
                }
            }
        }
    }

    public void Matched()
    {
        if (firstTry.idx == secondTry.idx)  
        {
            audioSource.PlayOneShot(matchClip);
            
            firstTry.DestroyCard();
            secondTry.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                audioSource.PlayOneShot(successClip, 0.05f);
                Time.timeScale = 0.0f;
                level += 1;
                Scene scene = GetCurrentScene(); 
                if (scene.name == "Main1Scene")
                    sceneName[0] = scene.name; 
                else if (scene.name == "Main2Scene")
                    sceneName[1] = scene.name;
                else if (scene.name == "Main3Scene")
                {
                    sceneName[2] = scene.name;

                    Achievements.SetActive(true);
                    Animator achAnim = Achievements.GetComponent<Animator>();
                    achAnim.SetTrigger("isActivate");
                    audioSource.PlayOneShot(matchClip);
                }

                elapsedTime = Time.time - startTime;

                if (elapsedTime < bestTime)
                {
                bestTime = elapsedTime;
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save();
                }

                CrealMSg.SetActive(true);
                CurrentTimeTxt.text = $"{elapsedTime:F1}��";
                BestTimeTxt.text = $"{bestTime:F1}��";
                Result.SetActive(true);
                Time.timeScale = 1;
                if (level >= saveLevel)
                {
                    GameLvSave();
                }
            }
        }
        else
        {
            firstTry.anim.SetTrigger("isClose");
            secondTry.anim.SetTrigger("isClose");
        }
    }

    private static void LoadChoiceScene()
    {
        SceneManager.LoadScene("ChoiceScene");
    }

    public void GameLvSave()
    {
        PlayerPrefs.SetInt("GameLv", toplevel);
        PlayerPrefs.Save();
    }
    IEnumerator GraduallyIncreasePitch(float targetPitch, float duration)
    {
        float startPitch = audioManager.audioSource.pitch;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            audioManager.audioSource.pitch = Mathf.Lerp(startPitch, targetPitch, elapsed / duration);
            yield return null;
        }
    }
    public void UpdateCardBackImages()
    {   
        Card[] cards = FindObjectsOfType<Card>();
        foreach (Card card in cards)
        {
            card.Setting(card.idx);
        }
    }

    Scene GetCurrentScene()
    {
        return SceneManager.GetActiveScene(); 
    }
}
