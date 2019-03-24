using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public void Newgame() {
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
