using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMGController : MonoBehaviour
{
    public enum Scene {Tutorial,Title,Menu}

    public Scene scene;

    public AudioSource audioSource;

    public AudioClip bgmTutorial, bgmTitle, bgmMenu, bgmGame;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (scene == Scene.Tutorial)
        {
            audioSource.PlayOneShot(bgmTutorial);
        }
        else if (scene == Scene.Title)
        {
            audioSource.PlayOneShot(bgmTitle);
        }
        else if(scene == Scene.Menu)
        {
            audioSource.PlayOneShot(bgmMenu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToGameBGM()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(bgmGame);
    }
    public void ChangeToMenuBGM()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(bgmMenu);
    }
}
