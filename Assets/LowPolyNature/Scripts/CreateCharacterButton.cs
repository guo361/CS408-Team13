using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreateCharacterButton : MonoBehaviour
{
    public InputField name;
    public GameObject message;

    void Start()
    {
        message = GameObject.Find("message");
        message.SetActive(false);
    }
    public void Button_Onclick()
    {
        if(name.text.Length > 0 && name.text.Length < 9)
        {
            PlayerPrefs.SetString("Username", name.text);
            Debug.Log("push");
            SceneManager.LoadScene("demo");
        }
        else
        {
            message.SetActive(true);
        }
        
    }

   /* public void Awake()
    {
        // Do not destroy this game object:
        DontDestroyOnLoad(name);
    }*/
}
