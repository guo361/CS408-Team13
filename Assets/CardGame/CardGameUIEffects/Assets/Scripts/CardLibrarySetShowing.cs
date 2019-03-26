using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardLibrarySetShowing : MonoBehaviour
{
    public Text strikeText;
    public Text guardText;
    public Text lifestealText;
    public Text swiftText;
    public int strikeNum;
    public int guardNum;
    public int lifestealNum;
    public int swiftNum;
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
            else if (temp.cardName == "Lifesteal")
            {
                lifestealNum++;
            }
            else if (temp.cardName == "Swift")
            {
                swiftNum++;
            }

            strikeText.text = "X " + strikeNum;
            guardText.text = "X " + guardNum;
            lifestealText.text = "X " + lifestealNum;
            swiftText.text = "X " + swiftNum;
        }
    }

   
}
