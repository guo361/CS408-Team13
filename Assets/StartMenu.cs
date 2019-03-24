using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame() {
        PlayerPrefs.SetInt("haveCards", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        

    }

    public void QuitGame() {
        Application.Quit();
    }
}
