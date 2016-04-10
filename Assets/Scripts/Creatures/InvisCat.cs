using UnityEngine;
using System.Collections;

public class InvisCat : Cat {

	// Use this for initialization
    private float count = 0;
    public float invisOff;
    private float countToInvis = 0;
    private bool Found = false;
    public GameObject partEffects;
    AudioSource InvisCatFX;
    float delay = 5.0f;

	public override void Start () 
    {
        base.Start();
        GetComponent<SpriteRenderer>().enabled = false;
        InvisCatFX = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	    count += Time.deltaTime;
        delay += Time.deltaTime;
        if (!InvisCatFX.isPlaying && delay >= 5.0f)
        {
            InvisCatFX.Play();
            delay = 0.0f;
        }

        if (GetComponent<GazeAwareComponent>().HasGaze) 
        {
            Found = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (count > invisOff && !Found) 
        {
            if (GetComponent<SpriteRenderer>().enabled)
            {
                Instantiate(partEffects, transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else 
            {
                Instantiate(partEffects, transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().enabled = true;
            }
            count = 0;
        }
	}
}
