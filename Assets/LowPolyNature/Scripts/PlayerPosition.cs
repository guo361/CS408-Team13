using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    private static PlayerPosition instance;
    public static PlayerPosition Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return instance ?? (instance = new GameObject("PlayerPosition").AddComponent<PlayerPosition>()); }
    }
}
