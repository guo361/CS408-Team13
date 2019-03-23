using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public static int Ehealth3;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("EHealth3", 50.0f);
        Ehealth3 = (int)PlayerPrefs.GetFloat("EHealth3", 50.0f);
        Debug.Log("enemy 3 health in demo " + PlayerPrefs.GetFloat("EHealth3", 50.0f));
    }


    // Update is called once per frame
    void Update()
    {
        if (Ehealth3 == 0)
        {
            Destroy(gameObject);
        }
    }
}
