using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNameMessagePopup : MonoBehaviour
{
    public GameObject message;
    
    public void Button_Onclick()
    {
        message = GameObject.Find("message");
        message.SetActive(false);

    }
}