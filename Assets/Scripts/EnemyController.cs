using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{

    public int hp;
    [SerializeField] int maxHP;

    [SerializeField] Text hpText;
    [SerializeField] Slider hpSlider;

    public GameObject gm, player;

    public int atPower;

    [SerializeField] Sprite[] images;

    public Animator animator;

    public GameObject ClearEffect;

    public GameObject MainCam;

    public AudioClip attack, damage, scEne1, scEne2, scEne3, scEne4, scPDown, scPUP, scSisseki, scRecover;

    public AudioClip scWin;

    public GameObject efPlayerPowerDown, efPlayerPowerUp, efPlayerHPMinus, efRecover;

    public GameObject skillUI;

    public Text skillMessage;

    public GameObject bgmManager;

    public int Lv1Hp, Lv2Hp, Lv3Hp, Lv4Hp, Lv1Pw, Lv2Pw, Lv3Pw, Lv4Pw;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHP()
    {
        MenuController lvJudge = gm.GetComponent<MenuController>();
        if (lvJudge.gameMode == MenuController.GameMode.Lv1)
        {
            maxHP = Lv1Hp;
            atPower = Lv1Pw;
            GetComponent<SpriteRenderer>().sprite = images[0];
        }
        else if (lvJudge.gameMode == MenuController.GameMode.Lv2)
        {
            maxHP = Lv2Hp;
            atPower = Lv2Pw;
            GetComponent<SpriteRenderer>().sprite = images[1];
        }
        else if (lvJudge.gameMode == MenuController.GameMode.Lv3)
        {
            maxHP = Lv3Hp;
            atPower = Lv3Pw;
            GetComponent<SpriteRenderer>().sprite = images[2];
        }
        else if (lvJudge.gameMode == MenuController.GameMode.Lv4)
        {
            maxHP = Lv4Hp;
            atPower = Lv4Pw;
            GetComponent<SpriteRenderer>().sprite = images[3];
        }
        hp = maxHP;
        hpText.text = "HP : " + hp + "/" + maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = hp;
    }

    void ReflectOnUI()
    {
        hpText.text = "HP : " + hp + "/" + maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = hp;
    }

    public void Damged(int d)
    {
        GetComponent<AudioSource>().PlayOneShot(damage);
        GetComponent<EnemyAnimation>().DamagedAnim();
        StartCoroutine(DamagedHP(d));
        DamagedHP(d);
    }


    IEnumerator DamagedHP(int d)
    {
        yield return new WaitForSeconds(0.5f);
        hp -= d;
        if (hp <= 0)
        {
            hp = 0;
            //anim
            ClearEffect.SetActive(true);
            animator.SetTrigger("Anim");
            gm.GetComponent<GMController>().PlayerWin();
            Invoke("GameClearEffFalse", 3f);
            MenuController mncontrl = gm.GetComponent<MenuController>();
            if (mncontrl.gameMode == MenuController.GameMode.Lv1)
            {
                Invoke("PlayWinSound", 2f);
                if (PlayerPrefs.GetInt("Lv1") < 1)
                {
                    //GetComponent<AudioSource>().PlayOneShot(scEne1);
                    gm.GetComponent<StatusManager>().SaveLv1();
                    gm.GetComponent<ItemManager>().EnableItemMessage("遅延証明書");
                }
            }
            else if (mncontrl.gameMode == MenuController.GameMode.Lv2)
            {
                //GetComponent<AudioSource>().PlayOneShot(scWin);
                if (PlayerPrefs.GetInt("Lv2") < 1)
                {
                    Invoke("PlayWinSound", 2f);
                    gm.GetComponent<StatusManager>().SaveLv2();
                    gm.GetComponent<ItemManager>().EnableItemMessage("代返");
                }
            }
            else if (mncontrl.gameMode == MenuController.GameMode.Lv3)
            {
                Invoke("PlayWinSound", 2f);
                //GetComponent<AudioSource>().PlayOneShot(scWin);
                if (PlayerPrefs.GetInt("Lv3") < 1)
                {
                    Invoke("PlayWinSound", 2f);
                    gm.GetComponent<StatusManager>().SaveLv3();
                    gm.GetComponent<ItemManager>().EnableItemMessage("友達のレジュメ");
                }
            }
            else if (mncontrl.gameMode == MenuController.GameMode.Lv4)
            {
                Invoke("PlayWinSound", 2f);
                if (PlayerPrefs.GetInt("Lv4") < 1)
                {
                    //GetComponent<AudioSource>().PlayOneShot(scEne4); 
                    Invoke("FadeOut", 5f);

                    Debug.Log("AllClear1");
                    gm.GetComponent<StatusManager>().SaveLv4();
                }
            }
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            Invoke("TurnEnd", 1.5f);
        }
        ReflectOnUI();
    }


    public void StartTurn()
    {
        //攻撃等行動を分岐する。今は攻撃
        int randomNum = Random.Range(0, 11);
        if (randomNum < 3)
        {
            MenuController lvJudge = gm.GetComponent<MenuController>();
            if (lvJudge.gameMode == MenuController.GameMode.Lv1 && player.GetComponent<PlayerController>().atPower > 10)
            {
                skillMessage.text = "渡辺先生の講評が厳しすぎてピンチ！\nプレイヤーの攻撃力がダウン！";
                skillUI.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1f);
                //skillUI.transform.DOMoveX(385, 1f);
                skillUI.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1000, 0), 1f).SetDelay(4f);
                //skillUI.transform.DOMoveX(-600f, 1f).SetDelay(4f);
                Invoke("Kouhyou", 4.5f);
                Invoke("InitSkillMessage",5f);
            }
            else
            {
                Invoke("Attack", 1.5f);
            }
            if (lvJudge.gameMode == MenuController.GameMode.Lv2 && atPower > 15)
            {
                skillMessage.text = "鬼塚先生はとんでもない量の課題を課した！\n先生の攻撃力がアップ！";

                skillUI.GetComponent<RectTransform>().DOAnchorPosX(0, 1f);
                skillUI.GetComponent<RectTransform>().DOAnchorPosX(-1000, 1f).SetDelay(4f);
                
                Invoke("Kadai", 4.5f);
                Invoke("InitSkillMessage", 5f);
            }
            if (lvJudge.gameMode == MenuController.GameMode.Lv3)
            {
                skillMessage.text = "大学事務局から怠惰な学生生活について叱責を受けた！\nプレイヤーのHPが減った！";

                skillUI.GetComponent<RectTransform>().DOAnchorPosX(0, 1f);
                skillUI.GetComponent<RectTransform>().DOAnchorPosX(-1000, 1f).SetDelay(4f);

                Invoke("Sisseki", 4.5f);
                Invoke("InitSkillMessage", 5f);
            }
            if (lvJudge.gameMode == MenuController.GameMode.Lv4 && hp < maxHP)
            {
                skillMessage.text = "学長から留年を盾に脅しを受けた！\n学長のHPが回復！";

                skillUI.GetComponent<RectTransform>().DOAnchorPosX(0, 1f);
                skillUI.GetComponent<RectTransform>().DOAnchorPosX(-1000, 1f).SetDelay(4f);

                Invoke("Odoshi", 3f);
                Invoke("InitSkillMessage", 5f);
            }
        }
        else
        {
            Invoke("Attack", 1.5f);
        }
    }

    void Attack()
    {
        GetComponent<AudioSource>().PlayOneShot(attack);
        GetComponent<EnemyAnimation>().AttackAnim();
        Invoke("AttackToPlayer", 0.8f);
    }

    void AttackToPlayer()
    {
        player.GetComponent<PlayerController>().Damaged(atPower);
    }

    //キャラ別効果
    void Kouhyou()
    {
        GetComponent<AudioSource>().PlayOneShot(scPDown);
        player.GetComponent<PlayerController>().atPower -= 10;
        efPlayerPowerDown.SetActive(true);
        StartCoroutine(EffectFalse(efPlayerPowerDown));
        efPlayerPowerDown.GetComponent<Animator>().SetTrigger("Anim");
        Invoke("TurnEnd", 2f);
    }

    void Kadai()
    {
        GetComponent<AudioSource>().PlayOneShot(scPUP);
        atPower += 15;
        efPlayerPowerUp.SetActive(true);
        StartCoroutine(EffectFalse(efPlayerPowerUp));
        efPlayerPowerUp.GetComponent<Animator>().SetTrigger("Anim");
        Invoke("TurnEnd", 2f);
    }

    void Sisseki()
    {
        GetComponent<AudioSource>().PlayOneShot(scSisseki);
        player.GetComponent<PlayerController>().Damaged(25);
        player.GetComponent<PlayerController>().SissekiAnim();
        Invoke("TurnEnd", 2f);
    }

    void Odoshi()
    {
        GetComponent<AudioSource>().PlayOneShot(scRecover);
        GetComponent<PlayerController>().hp += 30;
        if(hp >= maxHP)
        {
            hp = maxHP;
        }
        GetComponent<PlayerController>().ReflectOnUI();
        efRecover.SetActive(true);
        StartCoroutine(EffectFalse(efRecover));
        efRecover.GetComponent<Animator>().SetTrigger("Anim");
        Invoke("TurnEnd", 2f);
    }

    void InitSkillMessage()
    {
        skillUI.GetComponent<RectTransform>().position = new Vector2(1000, 0);
        //skillUI.transform.localPosition = new Vector3(976, 0, 0);
    }

    void TurnEnd()
    {
        gm.GetComponent<GMController>().TurnEnd();
    }

    IEnumerator EffectFalse(GameObject Eff)
    {
        yield return new WaitForSeconds(2f);
        Eff.SetActive(false);
    }

    void GameClearEffFalse()
    {
        ClearEffect.SetActive(false);
    }

    void PlayWinSound()
    {
        bgmManager.GetComponent<BMGController>().audioSource.Stop();
        GetComponent<AudioSource>().PlayOneShot(scWin);
    }


    void FadeOut()
    {
        Debug.Log("AllClear2");
        MainCam.GetComponent<FadeController>().FadeOut();
        Invoke("ToEndrole", 2f);
    }
    void ToEndrole()
    {
        Debug.Log("AllClear3");
        SceneManager.LoadScene("EndRole");
    }
}
