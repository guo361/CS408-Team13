using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastController : MonoBehaviour {

    [Tooltip("Toast pop up duration")]
    public float duration = 2.0f;
    private bool pendingDestroy = false;
    private Text text = null;

	void Start () {
        pendingDestroy = false;
        text = this.GetComponent<Text>();
    }
	
	void Update () {
        if(text.enabled == true && pendingDestroy == false)
        {
            pendingDestroy = true;
            StartCoroutine(selfDisable());
        }
	}

    IEnumerator selfDisable()
    {
        yield return new WaitForSeconds(duration);
        text.enabled = false;
        pendingDestroy = false;
    }
}
