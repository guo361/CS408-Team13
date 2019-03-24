using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEgg : MonoBehaviour
{
    public static float healthAmount;

    public turnSystemScript09 turnSystem;
    public TurnClass09 turnClass;
    public bool isTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        healthAmount = PlayerPrefs.GetFloat("Boss", 150.0f);
        healthAmount = healthAmount / 100;
        PlayerPrefs.SetFloat("enemyHP", healthAmount);
        Debug.Log("Boss" + healthAmount);


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
        healthAmount = PlayerPrefs.GetFloat("enemyHP");
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }

        isTurn = turnClass.isTurn;
        if (isTurn)
        {
            StartCoroutine("WaitAndMove");
        }
    }


    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(1f);
        //TODO: enemy turn
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;

        StopCoroutine("WaitAndMove");
    }
}
