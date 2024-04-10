using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

    public GameObject b_Tien, b_Daihen, b_Resume;

    public GameObject explainBtn;

    public Text explain;

    public enum ItemSelect {Tien,Daihen,Resume}
    public ItemSelect itemSelect;

    public GameObject enableItemTxt;
    public Text enableItemMessageTxt;

    public GameObject player;

    public AudioClip scTien, scDaihen, scResume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //遅延証明書UI表示非表示
        if (PlayerPrefs.GetInt("Lv1") < 1)
        {
            b_Tien.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        }
        else
        {
            b_Tien.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
        int tienchildCount = b_Tien.transform.childCount;
        for (int i = 0; i < tienchildCount; i++)
        {
            Transform childTransform = b_Tien.transform.GetChild(i);
            GameObject childObject = childTransform.gameObject;
            if (PlayerPrefs.GetInt("Lv1") < 1)
            {
                childObject.GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
            }
            else
            {
                childObject.GetComponent<Text>().color = new Color(1, 1, 1, 1f);
            }
        }

        //代返UI表示非表示
        if (PlayerPrefs.GetInt("Lv2") < 1)
        {
            b_Daihen.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        }
        else
        {
            b_Daihen.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
        int daihenChildCount = b_Daihen.transform.childCount;
        for (int i = 0; i < daihenChildCount; i++)
        {
            Transform childTransform = b_Daihen.transform.GetChild(i);
            GameObject childObject = childTransform.gameObject;
            childObject.GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
            if (PlayerPrefs.GetInt("Lv2") < 1)
            {
                childObject.GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
            }
            else
            {
                childObject.GetComponent<Text>().color = new Color(1, 1, 1, 1f);
            }
         }


        //レジュメUI表示非表示
        if (PlayerPrefs.GetInt("Lv3") < 1)
        {
            b_Resume.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        }
        else
        {
            b_Resume.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }
        int resumeChildCount = b_Resume.transform.childCount;
        for (int i = 0; i < resumeChildCount; i++)
        {
            Transform childTransform = b_Resume.transform.GetChild(i);
            GameObject childObject = childTransform.gameObject;
            if (PlayerPrefs.GetInt("Lv3") < 1)
            {
                childObject.GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
            }
            else
            {
                childObject.GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
            }
        }
    }

    public void Tien()
    {
        if(PlayerPrefs.GetInt("Lv1") > 0)
        {
            itemSelect = ItemSelect.Tien;
            explainBtn.SetActive(true);
            explain.text = "遅延証明書\n電車の遅延を証明する証明書。\n遅刻を取り消すことが出来る。\nHPが回復する";
        }
    }

    public void Daihen()
    {
        if (PlayerPrefs.GetInt("Lv2") > 0)
        {
            itemSelect = ItemSelect.Daihen;
            explainBtn.SetActive(true);
            explain.text = "代返\n出席確認時、友人に返事をしてもらう。\n教授の攻撃を下げる。";
        }
    }

    public void Resume()
    {
        if (PlayerPrefs.GetInt("Lv2") > 0)
        {
            itemSelect = ItemSelect.Resume;
            explainBtn.SetActive(true);
            explain.text = "友達のレジュメ\n課題やテストの前に\n友達のレジュメを見せてもらう。\n自分の攻撃力が上がる。";
        }
            
    }

    public void CloseExplain()
    {
        explainBtn.SetActive(false);
    }

    public void UseItem()
    {
        if (itemSelect == ItemSelect.Tien)
        {
            GetComponent<AudioSource>().PlayOneShot(scTien);
            player.GetComponent<PlayerController>().UseTien();
        }
        if (itemSelect == ItemSelect.Daihen)
        {
            GetComponent<AudioSource>().PlayOneShot(scDaihen);
            player.GetComponent<PlayerController>().UseDaihen();
        }
        if (itemSelect == ItemSelect.Resume)
        {
            GetComponent<AudioSource>().PlayOneShot(scResume);
            player.GetComponent<PlayerController>().UseResume();
        }
        explainBtn.SetActive(false);
    }

    public void UpdateItemStatus()
    {
        if (PlayerPrefs.GetInt("Lv1") >= 1)
        {
            b_Tien.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lv2") >= 1)
        {
            b_Daihen.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lv3") >= 1)
        {
            b_Resume.SetActive(true);
        }
    }

    public void EnableItemMessage(string itemname)
    {
        enableItemTxt.SetActive(true);
        enableItemMessageTxt.text = "アイテム、" + itemname + "が\n使えるようになりました！";
    }
    public void CloseMessage()
    {
        enableItemTxt.SetActive(false);
    }
}
