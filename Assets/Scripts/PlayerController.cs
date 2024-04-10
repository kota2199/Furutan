using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{

    public int hp;
    [SerializeField] int maxHP;

    [SerializeField] Text hpText;
    [SerializeField] Slider hpSlider;

    public GameObject gm, enemy;

    public int atPower;

    public Animator tienAnim,daihenAnim,resumeAnim;

    public GameObject animRecover, animPDown, animPUp;

    public GameObject loseAnim;

    public AudioClip attack, damage, pass, scTien, scResume, scDaihen, scRecover, scLose;

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

    public void SetValue()
    {
        MenuController lvJudge = gm.GetComponent<MenuController>();
        if (lvJudge.gameMode == MenuController.GameMode.Lv1)
        {
            maxHP = Lv1Hp;
            atPower = Lv1Pw;
        }
        else if (lvJudge.gameMode == MenuController.GameMode.Lv2)
        {
            maxHP = Lv2Hp;
            atPower = Lv3Pw;
        }
        else if (lvJudge.gameMode == MenuController.GameMode.Lv3)
        {
            maxHP = Lv3Hp;
            atPower = Lv4Pw;
        }
        else if (lvJudge.gameMode == MenuController.GameMode.Lv4)
        {
            maxHP = Lv4Hp;
            atPower = Lv4Pw;
        }
        hp = maxHP;
        hpText.text = "HP : " + hp + "/" + maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = hp;
    }

    public void ReflectOnUI()
    {
        hpText.text = "HP : " + hp + "/" + maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = hp;
    }

    public void Attack()
    {
        GetComponent<AudioSource>().PlayOneShot(attack);
        GetComponent<PlayerAnimation>().AttackAnim();
        Invoke("AttackToEnemy", 0.7f);
    }

    public void Pass()
    {
        GetComponent<AudioSource>().PlayOneShot(pass);
        Invoke("TurnEnd", 1.5f);
    }

    void AttackToEnemy()
    {
        //攻撃力のせっていをここでする
        enemy.GetComponent<EnemyController>().Damged(atPower);
    }

    public void Damaged(int d)
    {
        GetComponent<AudioSource>().PlayOneShot(damage);
        hp -= d;
        GetComponent<PlayerAnimation>().DamagedAnim();
        Invoke("DamagedHP", 0.5f);
    }

    void DamagedHP()
    {
        if (hp <= 0)
        {
            hp = 0;
            GetComponent<SpriteRenderer>().enabled = false;
            loseAnim.SetActive(true);
            loseAnim.GetComponent<Animator>().SetTrigger("Anim");
            Invoke("Lose", 1.5f);
        }
        else
        {
            Invoke("TurnEnd", 1.5f);
        }
        ReflectOnUI();
    }

    void Lose()
    {
        bgmManager.GetComponent<BMGController>().audioSource.Stop();
        GetComponent<AudioSource>().PlayOneShot(scLose);
        loseAnim.SetActive(false);
        gm.GetComponent<GMController>().PlayerLose();
    }

    public void UseTien()
    {
        gm.GetComponent<ItemEffect>().TienEffect();
        Invoke("DoTien", 1.5f);
    }

    void DoTien()
    {
        GetComponent<AudioSource>().PlayOneShot(scTien);
        hp += 10;
        ReflectOnUI();
        gm.GetComponent<GMController>().isPlaying = false;
        Debug.Log("Tien");
        animRecover.SetActive(true);
        tienAnim.SetTrigger("Anim");
        Invoke("TurnEnd", 1.5f);
    }

    public void UseDaihen()
    {
        gm.GetComponent<ItemEffect>().DaihenEffect();
        Invoke("DoDaihen", 1.5f);
    }

    void DoDaihen()
    {
        GetComponent<AudioSource>().PlayOneShot(scDaihen);
        enemy.GetComponent<EnemyController>().atPower -= 5;
        gm.GetComponent<GMController>().isPlaying = false;
        animPDown.SetActive(true);
        daihenAnim.SetTrigger("Anim");
        Debug.Log("Daihen");
        Invoke("TurnEnd", 1.5f);
    }

    public void UseResume()
    {
        gm.GetComponent<ItemEffect>().ResumeEffect();
        Invoke("DoResume", 1.5f);
    }

    public void DoResume()
    {
        GetComponent<AudioSource>().PlayOneShot(scResume);
        atPower += 10;
        gm.GetComponent<GMController>().isPlaying = false;
        animPUp.SetActive(true);
        resumeAnim.SetTrigger("Anim");
        Debug.Log("Resume");
        Invoke("TurnEnd", 1.5f);
    }

    public void SissekiAnim()
    {
        transform.DOScale(new Vector3(0.61f, 0.05f, 0.61f), 0.8f);
        transform.DOScale(new Vector3(0.61f, 0.61f, 0.61f), 0.8f);
    }

    void TurnEnd()
    {
        animRecover.SetActive(false);
        animPDown.SetActive(false);
        animPUp.SetActive(false);
        gm.GetComponent<GMController>().TurnEnd();
    }
}
