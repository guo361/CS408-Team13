
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bad2 : MonoBehaviour
{
    public static float healthAmount;
    public static int count;

    public turnSystemScript09 turnSystem;
    public TurnClass09 turnClass;
    public bool isTurn = false;
    public GameObject dialog;
    int cardnum;
    public Vector3 position;
    public Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
        healthAmount = PlayerPrefs.GetFloat("EHealth2");
        healthAmount = healthAmount / 100;
        PlayerPrefs.SetFloat("enemyHP", healthAmount);
        Debug.Log("enemy2" + healthAmount);
        dialog.SetActive(false);

        count = 0;

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
        if (healthAmount <= 0.01)
        {
            PlayerPrefs.SetInt("enemy2dead", 1);
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
        if (Goodegg.shield > 0)
        {
            real = real - Goodegg.shield;
            if (real <= 0)
            {
                Debug.Log(Goodegg.shield);
                Goodegg.shield = Goodegg.shield - Mathf.RoundToInt(100 * real);
                Debug.Log(real);
                Debug.Log(Goodegg.shield);
                return;
            }
           
        }
        Goodegg.healthAmount = Goodegg.healthAmount - real / 100.00f;
      
        
    }
    IEnumerator WaitAndMove()
    {
       
        //TODO: enemy turn
        int skill = Random.Range(0, 3);
        Debug.Log(skill);
        float damage = 0f;
        switch (skill)
        {
            case 0:

                //Goodegg.healthAmount = Goodegg.healthAmount - 0.05f;
                deductByShield(0.05f);//replace previous by counting shield
                PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                Debug.Log("count" + count);
                if (count < 3)
                {
                    Debug.Log("dot");

                    //Goodegg.healthAmount = Goodegg.healthAmount - 0.03f;
                    deductByShield(0.03f);//replace previous by counting shield
                    PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                    count++;
                }
                break;
            case 1:
                // Goodegg.healthAmount = Goodegg.healthAmount - 0.02f;
                deductByShield(0.02f);//replace previous by counting shield
                PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                Debug.Log("count" + count);
                if (count < 3)
                {
                    Debug.Log("dot");
                   // Goodegg.healthAmount = Goodegg.healthAmount - 0.03f;
                    deductByShield(0.03f);//replace previous by counting shield
                    PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                    count++;
                }
                break;
            case 2:
                //Goodegg.healthAmount = Goodegg.healthAmount - 0.03f;
                deductByShield(0.03f);//replace previous by counting shield
                PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                count = 0;
                Debug.Log("count" + count);
                if (count < 3)
                {
                    Debug.Log("dot");
                    // Goodegg.healthAmount = Goodegg.healthAmount - 0.03f;
                    deductByShield(0.03f);//replace previous by counting shield
                    PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                    count++;
                }
                break;
        }
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        yield return new WaitForSeconds(1f);
        Goodegg.shield = 0;
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
