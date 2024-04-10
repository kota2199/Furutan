using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackAnim()
    {
        transform.DOMove(new Vector3(20,0.8f,-1),0.5f);
        transform.DOMove(new Vector3(-4, 0.8f, -1), 0.5f);
        transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f),0.5f);
        transform.DOScale(new Vector3(0.61f, 0.61f, 0.61f), 0.5f);
    }
    public void DamagedAnim()
    {
        transform.DOMove(new Vector3(-20, 0.3f, -1), 0.5f);
        transform.DOMove(new Vector3(-4, 0.8f, -1), 0.5f);
        transform.DOScale(new Vector3(0.1f, 0.005f, 0.1f), 0.5f);
        transform.DOScale(new Vector3(0.61f, 0.61f, 0.61f), 0.5f);
    }
}
