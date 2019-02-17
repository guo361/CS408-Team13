using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreateCharacterButton : MonoBehaviour
{
    public InputField name;
    public void Button_Onclick()
    {
        PlayerPrefs.SetString("Username", name.text);
        Debug.Log("push");
        SceneManager.LoadScene("demo");
    }

   /* public void Awake()
    {
        // Do not destroy this game object:
        DontDestroyOnLoad(name);
    }*/
}
