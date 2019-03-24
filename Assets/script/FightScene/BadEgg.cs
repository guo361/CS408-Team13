using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEgg : MonoBehaviour
{
    public static float healthAmount;
    public static int baseATK;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = PlayerPrefs.GetFloat("EHealth1", 50.0f);
        healthAmount = healthAmount / 100;
        baseATK = 7;
        Debug.Log("enemy1" + healthAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0.01)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
