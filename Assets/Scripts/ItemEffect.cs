using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemEffect : MonoBehaviour
{

    public GameObject tien, daihen, resume;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TienEffect()
    {
        tien.transform.DOMove(new Vector3(0,0,-1), 0.5f);
        tien.transform.DOMove(new Vector3(0, -10, -1), 0.5f).SetDelay(1);
        tien.transform.position = new Vector3(0, 10, -1);
    }
    public void DaihenEffect()
    {
        daihen.transform.DOMove(new Vector3(0, 0, -1), 0.5f);
        daihen.transform.DOMove(new Vector3(0, -10, -1), 0.5f).SetDelay(1);
        daihen.transform.position = new Vector3(0, 10, -1);
    }

    public void ResumeEffect()
    {
        resume.transform.DOMove(new Vector3(0, 0, -1), 0.5f);
        resume.transform.DOMove(new Vector3(0, -10, -1), 0.5f).SetDelay(1);
        resume.transform.position = new Vector3(0, 10, -1);
    }
}
