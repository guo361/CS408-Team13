﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goodegg : MonoBehaviour
{
    public static float healthAmount;
    public turnSystemScript09 turnSystem;
    public static TurnClass09 turnClass;
    public static bool isTurn = false;

  //  public KeyCode moveKey;
    public static int mana;
    public static int totalMana;
    public static int shield;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = PlayerPrefs.GetFloat("Health", 100.00f);
        healthAmount = healthAmount / 100;
        Debug.Log("health in fight start" + healthAmount);
       
        totalMana = 3;
        mana = totalMana;
        shield = 0;
        turnSystem = GameObject.Find("Turn-basedSystem").GetComponent<turnSystemScript09>();

        foreach (TurnClass09 tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name)
            {
                turnClass = tc;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }

        isTurn = turnClass.isTurn;

    /*    if (isTurn)
        {
           
           if (Input.GetKeyDown(moveKey))
           {
                //TODO: hero attact here
               isTurn = false;
               turnClass.isTurn = isTurn;
               turnClass.wasTurnPrev = true;
           }
        }*/
    }
}
