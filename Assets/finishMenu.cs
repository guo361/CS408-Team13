using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finishMenu : MonoBehaviour
{
    public Text congrat;
    public Text love;
    void Start()
    {
        congrat.text = "おめでとう、" + PlayerPrefs.GetString("Username") + "君、アカリちゃんを助かりました。";
        love.text = "...君のことにが気になりました。";
    }
    public void exit()
    {
        Debug.Log("here");
        //Application.Quit();


    }
}
