using UnityEngine;
using System.Collections;

public abstract class Creature : MonoBehaviour {

	public abstract Vector3 Spawn();
	public abstract Vector3 Move();

	// Use this for initialization
	void Start () {
		transform.position = Spawn();
		Debug.Log("Spawn: " + transform.position.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Move();
		Debug.Log("Move: " + transform.position.ToString());
	}
}
