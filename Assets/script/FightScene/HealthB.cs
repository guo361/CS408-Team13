using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthB : MonoBehaviour
{
    Vector3 localScale;
    public Text Badp;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        Badp.text = string.Format("{0} ", Mathf.RoundToInt(BossEgg.healthAmount * 100));
    }

    // Update is called once per frame
    void Update()
    {
        Badp.text = string.Format("{0}/150 ", Mathf.RoundToInt(BossEgg.healthAmount * 100));
        localScale.x = BossEgg.healthAmount;
        transform.localScale = localScale;
    }
}
