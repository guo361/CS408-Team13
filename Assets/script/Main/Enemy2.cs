using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public static int Ehealth2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("EHealth2", 50.0f);
        Ehealth2 = (int)PlayerPrefs.GetFloat("EHealth2");
        
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("enemy2dead") == 1)
        {
            Destroy(gameObject);
        }
    }

}
