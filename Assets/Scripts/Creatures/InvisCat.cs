using UnityEngine;
using System.Collections;

public class InvisCat : Cat {

	// Use this for initialization
    private float count = 0;
    public float invisOff;
    private float countToInvis = 0;
    public GameObject partEffects;
	public override void Start () 
    {
        base.Start();
        GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	    count += Time.deltaTime;
        if (count > invisOff) 
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
