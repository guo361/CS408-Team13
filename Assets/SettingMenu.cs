using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public void Newgame() {
        CardLibrary.Instance.cardNumber = 0;
        CardLibrary.Instance.myCards = new List<Card>();
        PlayerPrefs.SetInt("infight", 0);
        PlayerPrefs.SetInt("haveCards", 0);
        PlayerPrefs.SetInt("enemy1dead", 0);
        PlayerPrefs.SetInt("enemy2dead", 0);
        PlayerPrefs.SetInt("enemy3dead", 0);
        PlayerPrefs.SetInt("bossdead", 0);
        PlayerPrefs.SetFloat("Health", 100.0f);
        SceneManager.LoadScene(2);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FullScreen() {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }
}
