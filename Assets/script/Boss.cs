using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static int Bhealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Boss", 150.0f);
        Bhealth = (int)PlayerPrefs.GetFloat("Boss", 150.0f);
        Debug.Log("Boss health in demo" + PlayerPrefs.GetFloat("Boss", 150.0f));
    }


    // Update is called once per frame
    void Update()
    {
        if (Bhealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
