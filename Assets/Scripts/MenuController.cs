using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject menuUIs, gameUIs;

    public enum GameMode {Lv1,Lv2,Lv3,Lv4}
    public GameMode gameMode;

    public GameObject player, enemy;

    public GameObject lv2Panel, lv3Panel, lv4Panel;

    public GameObject fader, HPUI;

    public Text remainTaniTxt;

    int remainTani;

    public GameObject bgmManager;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Lv1") >= 1)
        {
            lv2Panel.SetActive(false);
            remainTaniTxt.text = "留年回避まであと3単位";
        }
        else
        {
            remainTaniTxt.text = "留年回避まであと4単位";
        }
        if (PlayerPrefs.GetInt("Lv2") >= 1)
        {
            lv3Panel.SetActive(false);
            remainTaniTxt.text = "留年回避まであと2単位";
        }
        if (PlayerPrefs.GetInt("Lv3") >= 1)
        {
            lv4Panel.SetActive(false);
            remainTaniTxt.text = "留年回避まであと1単位";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToLv1()
    {
        menuUIs.GetComponent<AudioSource>().Play();
        gameMode = GameMode.Lv1;
        fader.GetComponent<FadeController>().AutoFade();
        Invoke("TransitionToGame", 0.5f);
    }

    public void ToLv2()
    {
        menuUIs.GetComponent<AudioSource>().Play();
        gameMode = GameMode.Lv2;
        fader.GetComponent<FadeController>().AutoFade();
        Invoke("TransitionToGame", 0.5f);
    }

    public void ToLv3()
    {
        menuUIs.GetComponent<AudioSource>().Play();
        gameMode = GameMode.Lv3;
        fader.GetComponent<FadeController>().AutoFade();
        Invoke("TransitionToGame", 0.5f);
    }

    public void ToLv4()
    {
        menuUIs.GetComponent<AudioSource>().Play();
        gameMode = GameMode.Lv4;
        fader.GetComponent<FadeController>().AutoFade();
        Invoke("TransitionToGame", 0.5f);
    }

    public void TransitionToGame()
    {
        player.SetActive(true);
        player.GetComponent<SpriteRenderer>().enabled = true;
        enemy.SetActive(true);
        enemy.GetComponent<SpriteRenderer>().enabled = true;
        HPUI.SetActive(true);
        player.GetComponent<PlayerController>().SetValue();
        enemy.GetComponent<EnemyController>().SetHP();
        menuUIs.SetActive(false);
        gameUIs.SetActive(true);
        GetComponent<GMController>().StartCoroutine("CountDown");
        bgmManager.GetComponent<BMGController>().ChangeToGameBGM();
    }

    public void OpenMenu()
    {
        if (PlayerPrefs.GetInt("Lv1") >= 1)
        {
            lv2Panel.SetActive(false);
            remainTaniTxt.text = "留年回避まであと3単位";
        }
        else
        {
            remainTaniTxt.text = "留年回避まであと4単位";
        }
        if (PlayerPrefs.GetInt("Lv2") >= 1)
        {
            lv3Panel.SetActive(false);
            remainTaniTxt.text = "留年回避まであと2単位";
        }
        if (PlayerPrefs.GetInt("Lv3") >= 1)
        {
            lv4Panel.SetActive(false);
            remainTaniTxt.text = "留年回避まであと1単位";
        }
        menuUIs.SetActive(true);
        gameUIs.SetActive(false);
    }
}
