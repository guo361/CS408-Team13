using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEgg : MonoBehaviour
{
    public static float healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = PlayerPrefs.GetFloat("EHealth1", 50.0f);
        healthAmount = healthAmount / 100;
        Debug.Log("enemy1" + healthAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
