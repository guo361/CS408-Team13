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
    // Start is called before the first frame update

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
        if (healthAmount <= 0.001)
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
    void deductByShield(float damage)
    {
        int real = Mathf.RoundToInt(damage * 100);
        int temp = real;
        if (Goodegg.shield > 0)
        {
            real = real - Goodegg.shield;
            if (real <= 0)
            {
                
                Goodegg.shield = Goodegg.shield - temp;
                
                return;
            }
            else
            {
                Goodegg.shield = 0;
            }

        }
       
        Goodegg.healthAmount = Goodegg.healthAmount - (real / 100.00f);
        
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(1f);
        //TODO: enemy turn
        // Goodegg.healthAmount = Goodegg.healthAmount - 0.05f;
        deductByShield(0.05f);
        PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;

        Goodegg.count = 1;
        StopCoroutine("WaitAndMove");
        
    }
    public void addNewCard()
    {
        //random generate card num
        int cardnum = Random.Range(0, 4);
        //add new cards
        Card newcard = new Card();
        if (cardnum == 0)
        {
            newcard.cardName = "Strike";

        }
        else if (cardnum == 1)
        {
            newcard.cardName = "Guard";

        }
        else if (cardnum == 2)
        {
            newcard.cardName = "Lifesteal";
        }
        else
        {
            newcard.cardName = "Swift";
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
