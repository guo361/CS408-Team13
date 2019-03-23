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
        Ehealth2 = (int)PlayerPrefs.GetFloat("EHealth2", 50.0f);
        Debug.Log("enemy 2 health in demo " + PlayerPrefs.GetFloat("EHealth2", 50.0f));
    }


    // Update is called once per frame
    void Update()
    {
        if (Ehealth2 == 0)
        {
            Destroy(gameObject);
        }
    }

}
