using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public Text messageTxt;

    public Image boy;

    public Sprite[] boyImage;

    public string[] messages = 
        { "僕は大学3年生の留年男(とどめとしお)。今は後期の終盤で、最終課題や試験が控えている。"
        , "しかし今までサボったり寝坊したりしてまともに講義を受けていない。\n当然、今までもサボり続けてきた。"
        , "今までは友達に代わりに出席を出してもらったり、\nレジュメを借りたりしてしのいできた。"
        , "しかも僕は奨学金を借りているので留年は許されない…！\nどんな手を使ってでも絶対進級してやる！"
        };

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FadeController>().FadeIn();
        StartCoroutine("Tutorial");
        if(PlayerPrefs.GetInt("FirstBoot") > 0)
        {
            SceneManager.LoadScene("Title");
        }
    }
    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(3);

        for(int i = 0; i < messages.Length; i++)
        {
            boy.sprite = boyImage[i];
            messageTxt.text = messages[i];
            yield return new WaitForSeconds(5);
        }

        GetComponent<FadeController>().FadeOut();
        yield return new WaitForSeconds(3);
        PlayerPrefs.SetInt("FirstBoot", 1);
        SceneManager.LoadScene("Title");
    }
}
