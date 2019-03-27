using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public static int Bhealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Boss", 150.0f);
        Bhealth = (int)PlayerPrefs.GetFloat("Boss");
        
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("bossdead") == 1)
        {
            PlayerPrefs.SetInt("infight", 0);
            Destroy(gameObject);
        }
    }
}
