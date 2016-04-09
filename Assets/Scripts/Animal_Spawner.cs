using UnityEngine;
using System.Collections;

public class Animal_Spawner : MonoBehaviour {

    
    private float SpawnTimer = 0;
    public float TimeRange;
    private float TimeToSpawn;
    public GameObject Animal;
    private int MaxSpawnCount = 10;
	// Use this for initialization
	void Start () {
        TimeToSpawn = Random.Range(0.0f, TimeRange);
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Animal").Length < MaxSpawnCount)
        {
            SpawnTimer += Time.deltaTime;
            if (SpawnTimer >= TimeToSpawn)
            {
                SpawnTimer = 0;
                TimeToSpawn = Random.Range(0.0f, TimeRange);
                Instantiate(Animal, transform.position, Quaternion.identity);
            }
        }
	}
}
