﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int Ehealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("EHealth1", 50.0f);
        Ehealth = (int)PlayerPrefs.GetFloat("EHealth1");
        
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("enemy1dead") == 1)
        {
            Destroy(gameObject);
        }
    }


}
