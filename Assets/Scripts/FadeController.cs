using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public GameObject fadePanel;
    bool fadeout = false, fadein = true, autoFade = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout)
        {
            Color color = fadePanel.GetComponent<Image>().color;
            if (color.a <= 1.0f)
            {
                color.a += 0.05f;
                fadePanel.GetComponent<Image>().color = color;
            }
            else
            {
                fadeout = false;
            }
        }
        if (fadein)
        {
            Color color = fadePanel.GetComponent<Image>().color;
            if (color.a >= 0f)
            {
                color.a -= 0.05f;
                fadePanel.GetComponent<Image>().color = color;
            }
            else
            {
                fadein = false;
                fadePanel.SetActive(false);
            }
        }

        if (autoFade)
        {

        }
    }

    public void FadeOut()
    {
        fadePanel.SetActive(true);
        fadeout = true;
    }

    public void FadeIn()
    {
        fadePanel.SetActive(true);
        fadein = true;
    }

    public void AutoFade()
    {
        fadePanel.SetActive(true);
        fadeout = true;
        Invoke("AuteFadeIn", 0.5f);
    }

    public void AuteFadeIn()
    {
        fadein = true;
    }
}
