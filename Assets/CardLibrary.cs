using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLibrary : MonoBehaviour
{
    
    public List<Card> myCards = new List<Card>();
    public int cardNumber;
    private static CardLibrary instance;
    public static CardLibrary Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return instance ?? (instance = new GameObject("CardLibrary").AddComponent<CardLibrary>()); }
    }
   



}
