using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreateCharacterButton : MonoBehaviour
{
    public InputField playername;
    public GameObject message;

    void Start()
    {
        message = GameObject.Find("message");
        message.SetActive(false);
    }
    public void Button_Onclick()
    {
        if (playername.text.Length > 0 && playername.text.Length < 9)
        {
            PlayerPrefs.SetString("Username", playername.text);
            Debug.Log("push");
            //SceneManager.LoadScene("demo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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