using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Tooltip("Camera offset in y-axis under different aspects")]
    public List<float> cameraYOffset = new List<float>();
    [Tooltip("Aspects to fit")]
    public List<float> cameraAspectRef = new List<float>();

    private const float EPS = 0.05f;                 // Abs(A-B)<=EPS <=> A=B
    private const float CAMERA_POS_Z = -30.0f;       // Camera.position.z

    void Start () {
        // Calculte the new orthographicSize under aspect ratio 16:9
        var realAspect = this.GetComponent<Camera>().aspect;
        var newSize = this.GetComponent<Camera>().orthographicSize / this.GetComponent<Camera>().aspect * (16.0f / 9.0f);
        this.GetComponent<Camera>().orthographicSize = newSize;
        // Rise up the camera to hide the card bottom in hand
        for (int i = 0; i < cameraAspectRef.Count; i++)
        {
            if (Mathf.Abs(realAspect - cameraAspectRef[i]) <= EPS)
            {
                if (cameraYOffset[i] < 0)
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + cameraYOffset[i], CAMERA_POS_Z);
                }
                break;
            }
        }
    }
}
