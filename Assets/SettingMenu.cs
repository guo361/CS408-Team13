using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public void Newgame() {
        SceneManager.LoadScene(0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
