using UnityEngine;
using System.Collections;

public class Animal_GazeAwareness : MonoBehaviour {

    public GameObject Fireworks;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dot")
        {
            Instantiate(Fireworks, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
