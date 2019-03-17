using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour {

    [Tooltip("Pending seconds to disapear")]
    public float pendingTime = 0.8f;
    [Tooltip("Scale decrease delta")]
    public float scaleDecDelta = 0.005f;
    [Tooltip("Alpha decrease delta")]
    public float alphaDecDelta = 0.02f;

    private float startTime;


    void Start () {
        startTime = Time.time;
    }
	
	void Update () {
        // The attack and defense icon hold on for a while
        if (Time.time - startTime >= pendingTime)
        {
            var scale = this.transform.localScale;
            this.transform.localScale = new Vector3(scale.x - scaleDecDelta, scale.y - scaleDecDelta, scale.z - scaleDecDelta);  // Scale decrease
            var color = this.GetComponent<SpriteRenderer>().material.color;
            var new_color = new Color(color.r, color.g, color.b, color.a - alphaDecDelta);  // Alpha decrease
            if (new_color.a <= 0.0f)
            {
                Destroy(gameObject);  // Self destroy when the alpha decrease to 0
            }
            this.GetComponent<SpriteRenderer>().material.color = new_color;
        }
    }
}
