using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldCount : MonoBehaviour
{

    public Text Shield;
    void Start()
    {

        Shield.text = string.Format("{0}", Goodegg.shield);
    }

    // Update is called once per frame
    void Update()
    {

        Shield.text = string.Format("{0}", Goodegg.shield);

    }
}
