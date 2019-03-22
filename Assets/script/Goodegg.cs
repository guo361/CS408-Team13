﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goodegg : MonoBehaviour
{
    public static float healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = PlayerPrefs.GetFloat("Health", 100.0f);
        healthAmount = healthAmount / 100;
        Debug.Log("health in fight start" + healthAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
