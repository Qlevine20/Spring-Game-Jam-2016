using UnityEngine;
using System.Collections;

public class Fireworks_DestroyatAnimEnd : MonoBehaviour {

    AudioSource[] ExplosionFX;

    private IEnumerator KillOnAnimationEnd(AudioSource Explosion)
    {
        Explosion.Play();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        ExplosionFX = GetComponents<AudioSource>();
        int x = Random.Range(0, 2);
        StartCoroutine(KillOnAnimationEnd(ExplosionFX[x]));
    }
	
	// Update is called once per frame
	void Update () {
	}
}
