using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{

    public int clear1, clear2, clear3, clear4;

    // Start is called before the first frame update
    void Start()
    {
        clear1 = PlayerPrefs.GetInt("Lv1");
        clear2 = PlayerPrefs.GetInt("Lv2");
        clear3 = PlayerPrefs.GetInt("Lv3");
        clear4 = PlayerPrefs.GetInt("Lv4");
        Debug.Log("c1" + clear1 + "c2" + clear2 + "c3" + clear3 + "c4" + clear4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }

    public void SaveLv1()
    {
        PlayerPrefs.SetInt("Lv1", 1);
        PlayerPrefs.Save();
    }
    public void SaveLv2()
    {
        PlayerPrefs.SetInt("Lv2", 1);
        PlayerPrefs.Save();
    }
    public void SaveLv3()
    {
        PlayerPrefs.SetInt("Lv3", 1);
        PlayerPrefs.Save();
    }
    public void SaveLv4()
    {
        PlayerPrefs.SetInt("Lv4", 1);
        PlayerPrefs.Save();
    }
}
