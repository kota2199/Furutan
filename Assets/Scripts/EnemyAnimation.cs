using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagedAnim()
    {
        transform.DOMove(new Vector3(15, 0.8f, -1), 0.5f);
        transform.DOMove(new Vector3(4, 0.8f, -1), 0.5f);
        transform.DOScale(new Vector3(0.1f, 0.005f, 0.1f), 0.5f);
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
    }

    public void AttackAnim()
    {
        transform.DOMove(new Vector3(-15, 0.8f, -1), 0.5f);
        transform.DOMove(new Vector3(4, 0.8f, -1), 0.5f);
        transform.DOScale(new Vector3(1.5f, 1.2f, 0.1f), 0.5f);
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.5f);
    }
}
