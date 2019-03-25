using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCount : MonoBehaviour
{

    public Text Mana;
    void Start()
    {

        Mana.text = string.Format("{0}/{1}", Goodegg.mana, Goodegg.totalMana);
    }

    // Update is called once per frame
    void Update()
    {

        Mana.text = string.Format("{0}/{1}", Goodegg.mana, Goodegg.totalMana);

    }
}
