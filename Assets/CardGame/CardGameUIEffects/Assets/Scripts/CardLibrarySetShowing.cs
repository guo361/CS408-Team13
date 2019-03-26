using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardLibrarySetShowing : MonoBehaviour
{
    public Text strikeText;
    public Text guardText;
    public int strikeNum;
    public int guardNum;
    // Start is called before the first frame update
    void Start()
    {
        strikeNum = 0;
        guardNum = 0;
        foreach(Card temp in CardLibrary.Instance.myCards)
        {
            if(temp.cardName == "Strike")
            {
                strikeNum++;
            }
            else if(temp.cardName == "Guard")
            {
                guardNum++;
            }
           
            strikeText.text = "X " + strikeNum;
            guardText.text = "X " + guardNum;
        }
    }

   
}
