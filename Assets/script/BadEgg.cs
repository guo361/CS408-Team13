using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEgg : MonoBehaviour
{
    public static int healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 100;
        healthAmount = healthAmount / 100;
        Debug.Log("enemy" + healthAmount);
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
