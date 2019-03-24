using System.Collections; using System.Collections.Generic; using UnityEngine;  public class GlobalComponent : MonoBehaviour {     public static GlobalComponent Instance;     public Vector3 position;      void Awake()     {
        //if (Instance == null)
        //{
        DontDestroyOnLoad(gameObject);
        Instance = this;
        //}
        //else if (Instance != this)
        //{
        //    //Destroy(gameObject);
        //}
    } }  