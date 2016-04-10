using UnityEngine;
using System.Collections;

public class Fireworks_DestroyatAnimEnd : MonoBehaviour {

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(KillOnAnimationEnd());
    }
	
	// Update is called once per frame
	void Update () {
	}
}
