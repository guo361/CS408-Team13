using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFight : MonoBehaviour
{
    Vector3 localScale;

    public Text Goodp;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        Goodp.text = string.Format("{0} ", Mathf.RoundToInt(Goodegg.healthAmount * 100));
    }

    // Update is called once per frame
    void Update()
    {
            Goodp.text = string.Format("{0} ", Mathf.RoundToInt(Goodegg.healthAmount * 100));
            localScale.x = Goodegg.healthAmount;
            transform.localScale = localScale;
    }
}
