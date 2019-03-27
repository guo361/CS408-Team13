using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEgg : MonoBehaviour
{
    public static float healthAmount;

    public turnSystemScript09 turnSystem;
    public TurnClass09 turnClass;
    public bool isTurn = false;
    public Vector3 position;
    public Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
        healthAmount = PlayerPrefs.GetFloat("Boss");
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
        transform.rotation = rotation;
        transform.position = position;
        healthAmount = PlayerPrefs.GetFloat("enemyHP");
        if (healthAmount <= -20)
        {
            PlayerPrefs.SetInt("bossdead", 1);
            Destroy(gameObject);
            SceneManager.LoadScene(2);
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
        //yield return new WaitForSeconds(1f);
        //transform.position += transform.right * -7;
        //Debug.Log("forward");
        //print(transform.localPosition.x);
        yield return new WaitForSeconds(1f);
        //TODO: enemy turn
        //transform.position += transform.right * 7;
        //print(transform.localPosition.x);
        //Debug.Log("back");
        //isForward = false;
        int skill = Random.Range(0, 4);
        Debug.Log(skill);
        switch (skill)
        {
            case 0:
                Goodegg.totalMana = 3;
                // Goodegg.healthAmount = Goodegg.healthAmount - 0.1f;
                deductByShield(0.1f);
                PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                break;
            case 1:
                Goodegg.totalMana = 3;
                //Goodegg.healthAmount = Goodegg.healthAmount - 0.13f;
                deductByShield(0.13f);
                PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                break;
            case 2:
                Goodegg.totalMana = 3;
                // Goodegg.healthAmount = Goodegg.healthAmount - 0.1f;
                deductByShield(0.1f);
                PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                if (healthAmount < 0.95f)
                {
                    healthAmount = healthAmount + 0.05f;
                    PlayerPrefs.SetFloat("enemyHP", healthAmount);
                }
                else
                {
                    Goodegg.totalMana = Goodegg.totalMana - 1;
                    Goodegg.mana = Goodegg.totalMana;
                }
                break;
            case 3:
                Goodegg.totalMana = 3;
                //Goodegg.healthAmount = Goodegg.healthAmount - 0.07f;
                deductByShield(0.07f);
                PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
                break;
        }
        //Goodegg.healthAmount = Goodegg.healthAmount - 0.1f;
        //PlayerPrefs.SetFloat("Health", Goodegg.healthAmount * 100);
        //yield return new WaitForSeconds(1f);

        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        //transform.position += transform.right * 7;
       
        Goodegg.count = 1;
        StopCoroutine("WaitAndMove");
    }
}
