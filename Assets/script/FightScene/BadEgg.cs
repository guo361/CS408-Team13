using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEgg : MonoBehaviour
{
    public static float healthAmount;
    public turnSystemScript09 turnSystem;
    public TurnClass09 turnClass;
    public bool isTurn = false;
    public GameObject dialog;
    public Vector3 position;
    public Quaternion rotation;
    //bool flag = false;
    // Start is called before the first frame update
    int cardnum;
    void Start()
    {
        //flag = false;
        position = transform.position;
        rotation = transform.rotation;
        healthAmount = PlayerPrefs.GetFloat("EHealth1");
        healthAmount = healthAmount / 100;
        PlayerPrefs.SetFloat("enemyHP", healthAmount);
        Debug.Log("enemy1" + healthAmount);
        dialog.SetActive(false);

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
        transform.rotation = rotation;
        transform.position = position;
        healthAmount = PlayerPrefs.GetFloat("enemyHP");
        if (healthAmount <= 0.01)
        {
            PlayerPrefs.SetInt("enemy1dead", 1);
            //display reward windows
            dialog.SetActive(true);
           
        }

        isTurn = turnClass.isTurn;
        if (isTurn)
        {
            StartCoroutine("WaitAndMove");
        }
    }


    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(10f);
        //TODO: enemy turn
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;

        StopCoroutine("WaitAndMove");
    }
    public void addNewCard()
    {
        //random generate card num
        cardnum = Random.Range(0, 2);
        Debug.Log("******************** " + cardnum);
        //add new cards
        Card newcard = new Card();
        if (cardnum == 0)
        {
            newcard.cardName = "Strike";

        }
        else
        {
            newcard.cardName = "Guard";

        }
        CardLibrary.Instance.myCards.Add(newcard);
        CardLibrary.Instance.cardNumber += 1;


    }
    public void okbtn()
    {
        addNewCard();
        Destroy(gameObject);
        SceneManager.LoadScene(2);

    }

}
