using UnityEngine;
using System.Collections;

public class Animal_Spawner : MonoBehaviour {

	public Creature prefab;
	public float interval;

	private float lastSpawn;

	// Use this for initialization
	void Start () {
		Instantiate(prefab);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Update");
		if(lastSpawn-interval < Time.time){
			Debug.Log("Update:Instantiate");
			Instantiate(prefab);
			lastSpawn = Time.time;
		}
	}
}
