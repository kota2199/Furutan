using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleAnimation : MonoBehaviour
{

    public GameObject title;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TitleAnim");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TitleAnim()
    {
        while (true)
        {
            title.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 1f);
            yield return new WaitForSeconds(1f);
            title.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f);
            yield return new WaitForSeconds(1f);
        }
    }
}
