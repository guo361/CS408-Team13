using System.Collections;
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
    public static int shield;
  //  public KeyCode moveKey;
    public static int mana;
    public static int totalMana;
    public GameObject DieMsg;
    public static int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        DieMsg.SetActive(false);
        healthAmount = PlayerPrefs.GetFloat("Health", 100.0f);

    // Start is called before the first frame update

        healthAmount = healthAmount / 100;
        Debug.Log("health in fight start" + healthAmount);

        totalMana = 3;
        mana = totalMana;
        shield = 0;
        PlayerPrefs.SetInt("Shield", 0);
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
        if (healthAmount <= 0.001)
        {
            DieMsg.SetActive(true);
        }

        isTurn = turnClass.isTurn;

       if (isTurn && count == 1)
        {

            /* if (Input.GetKeyDown(moveKey))
             {
                  //TODO: hero attact here
                 isTurn = false;
                 turnClass.isTurn = isTurn;
                 turnClass.wasTurnPrev = true;
             }*/
            StartCoroutine("WaitAndMove");
            
        }
    }
    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(0.3f);
        //TODO: enemy turn
        // Goodegg.healthAmount = Goodegg.healthAmount - 0.05f;

        shield = 0;
        count--;
        StopCoroutine("WaitAndMove");

    }
    public void restartBtn()
    {
        Destroy(gameObject);

        //SceneManager.LoadScene(0);
    }

    public void quitBtn()
    {
        //Destroy(gameObject);
        Application.Quit();
    }
}
