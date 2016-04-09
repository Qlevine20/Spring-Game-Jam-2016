using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animal_Spawner : MonoBehaviour {

	//public Creature prefab;
	public List<Creature> prefabs;
	public float interval;

	private float LastSpawn;
	private int size;

	// Use this for initialization
	void Start () {
		size = prefabs.Count;
		Instantiate(prefabs[Random.Range(0,size)]);
		LastSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(interval-LastSpawn < 0){

			Instantiate(prefabs[Random.Range(0,size)]);
			LastSpawn = 0;
		}
		LastSpawn += Time.deltaTime;
	}
}
