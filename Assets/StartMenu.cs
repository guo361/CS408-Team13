using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame() {
        PlayerPrefs.SetInt("infight", 0);
        PlayerPrefs.SetInt("haveCards", 0);
        PlayerPrefs.SetInt("enemy1dead", 0);
        PlayerPrefs.SetInt("enemy2dead", 0);
        PlayerPrefs.SetInt("enemy3dead", 0);
        PlayerPrefs.SetInt("bossdead", 0);
        PlayerPrefs.SetFloat("Health", 100.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        

    }

    public void QuitGame() {
        Application.Quit();
    }
}
