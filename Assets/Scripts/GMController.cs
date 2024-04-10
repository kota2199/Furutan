using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GMController : MonoBehaviour
{

    int cd = 3;
    public GameObject cdText;

    public bool isPlaying = false;

    public GameObject player, enemy;

    public enum Turn {Player, Enemy}

    public Turn turn;

    public Text turnTxt;

    public GameObject playerUI;

    public GameObject winUI, loseUI;

    public Text winMessage, loseMessage;

    public GameObject fader;

    public AudioClip scClick;

    public GameObject bmgManager;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("CountDown");
        turn = Turn.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            playerUI.SetActive(true);
        }
        else
        {
            playerUI.SetActive(false);
        }
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        cdText.SetActive(true);
        Text cd_text = cdText.GetComponent<Text>();
        cd_text.text = "3";
        yield return new WaitForSeconds(1);
        cd_text.text = "2";
        yield return new WaitForSeconds(1);
        cd_text.text = "1";
        yield return new WaitForSeconds(1);
        cd_text.text = "Go!";
        yield return new WaitForSeconds(1);
        cdText.SetActive(false);
        isPlaying = true;
        GetComponent<ItemManager>().UpdateItemStatus();
    }

    public void PlayerAttack()
    {
        player.GetComponent<PlayerController>().Attack();
        isPlaying = false;
    }
    public void PlayerPass()
    {
        player.GetComponent<PlayerController>().Pass();
        isPlaying = false;
    }

    public void TurnEnd()
    {
        if(turn == Turn.Player)
        {
            isPlaying = false;
            turn = Turn.Enemy;
            turnTxt.text = "大学側のターン";
            turnTxt.color = new Color(1,0.5f,0.3f,255);
            enemy.GetComponent<EnemyController>().StartTurn();
        }
        else
        {
            turn = Turn.Player;
            turnTxt.text = "学生のターン";
            turnTxt.color = new Color(0.2f,0.7f,1,225);
            isPlaying = true;
        }
    }

    public void PlayerWin()
    {
        Invoke("PlayerWinAfAnim", 3f);
    }

    public void PlayerWinAfAnim()
    {
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv1)
        {
            winMessage.text = "普通の渡辺教授を倒して単位ゲット！\n必要単位まであと3単位！";
        }
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv2)
        {
            winMessage.text = "学部長を倒して単位ゲット！\n必要単位まであと2単位！";
        }
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv3)
        {
            winMessage.text = "大学事務局を倒して単位ゲット！\n必要単位まであと1単位！";
        }
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv4)
        {
            winMessage.text = "学長を倒して単位ゲット！\n無事単位取得！";
        }
        winUI.SetActive(true);
    }

    public void PlayerLose()
    {
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv1)
        {
            loseMessage.text = "単位をもらえなかった...\n必要単位まであと4単位";
        }
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv2)
        {
            loseMessage.text = "単位をもらえなかった...\n必要単位まであと3単位";
        }
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv3)
        {
            loseMessage.text = "単位をもらえなかった...\n必要単位まであと2単位";
        }
        if (GetComponent<MenuController>().gameMode == MenuController.GameMode.Lv4)
        {
            loseMessage.text = "単位をもらえなかった...\n必要単位まであと1単位";
        }
        loseUI.SetActive(true);
    }

    public void Retry()
    {
        GetComponent<AudioSource>().PlayOneShot(scClick);
        fader.GetComponent<FadeController>().AutoFade();
        Invoke("TransitionRetry", 0.5f);
    }

    public void ToMenu()
    {
        GetComponent<AudioSource>().PlayOneShot(scClick);
        fader.GetComponent<FadeController>().AutoFade();
        Invoke("TransitionToMenu", 0.5f);
    }

    public void TransitionToMenu()
    {
        player.SetActive(false);
        enemy.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);
        GetComponent<MenuController>().OpenMenu();
        bmgManager.GetComponent<BMGController>().ChangeToMenuBGM();
    }

    public void TransitionRetry()
    {
        player.GetComponent<PlayerController>().SetValue();
        player.GetComponent<SpriteRenderer>().enabled = true;
        enemy.GetComponent<EnemyController>().SetHP();
        enemy.GetComponent<SpriteRenderer>().enabled = true;
        winUI.SetActive(false);
        loseUI.SetActive(false);
        isPlaying = false;
        turn = Turn.Player;
        StartCoroutine("CountDown");
        bmgManager.GetComponent<BMGController>().ChangeToGameBGM();
    }
}