using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {

	public abstract Vector3 Spawn();
	public abstract Vector3 Move();
    
	// Use this for initialization
	public virtual void Start () {
        if (transform.childCount > 0) 
        {
            Destroy(transform.GetChild(0).gameObject);
        }
		transform.position = Spawn();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		transform.position = Move();
	}
}
