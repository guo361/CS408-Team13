using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthE3 : MonoBehaviour
{
    Vector3 localScale;
    public Text Badp;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        Badp.text = string.Format("{0} ", Mathf.RoundToInt(Bad3.healthAmount * 100));
    }

    // Update is called once per frame
    void Update()
    {
        if (Bad3.healthAmount < 0)
        {
            Badp.text = string.Format("{0} ", "0");
            localScale.x = 0;
            transform.localScale = localScale;
        }
        else
        {
            Badp.text = string.Format("{0} ", Mathf.RoundToInt(Bad3.healthAmount * 100));
            localScale.x = Bad3.healthAmount;
            transform.localScale = localScale;
        }
    }
}
