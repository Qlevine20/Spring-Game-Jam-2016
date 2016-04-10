using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animal_Spawner : MonoBehaviour {

	//public Creature prefab;
	public List<Creature> prefabs;
	public float interval;

	private float LastSpawn;
	private int size;
    public float harder;
    private int sizeChange = 2;
    private float counter = 0;

	// Use this for initialization
	void Start () {
		size = prefabs.Count;
		Instantiate(prefabs[Random.Range(0,size-sizeChange)]);
		LastSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter > harder && sizeChange > 0) 
        {
            sizeChange -= 1;
            counter = 0;
        }
		if(interval-LastSpawn < 0){
			Instantiate(prefabs[Random.Range(0,size-sizeChange)]);
			LastSpawn = 0;
		}
		LastSpawn += Time.deltaTime;
	}
}
