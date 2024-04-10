using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndRoleManager : MonoBehaviour
{

    public Text messageText;

    public GameObject boy;

    public Sprite guts;

    bool boyfadeout = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FadeController>().FadeIn();
        StartCoroutine("Messages");
    }

    // Update is called once per frame
    void Update()
    {
        if (boyfadeout)
        {
            Color color = boy.GetComponent<SpriteRenderer>().color;
            if (color.a >= 0f)
            {
                color.a -= 0.005f;
                boy.GetComponent<SpriteRenderer>().color = color;
            }
            else
            {
                boyfadeout = false;
            }
        }
    }
    IEnumerator Messages()
    {
        yield return new WaitForSeconds(3);
        messageText.text = "なんとか3年生の後期でフル単を達成して\n4年生になることが出来た...";
        yield return new WaitForSeconds(5);
        messageText.text = "ゼミで卒論頑張るぞー！\nまぁ、一旦進級できたしゆっくりしよう...";
        boy.GetComponent<SpriteRenderer>().sprite = guts;
        yield return new WaitForSeconds(3);
        boyfadeout = true;
        yield return new WaitForSeconds(3);
        GetComponent<FadeController>().FadeOut();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Title");
    }
}
