using UnityEngine;
using System.Collections;

public class CenterDot : MonoBehaviour {

    public KeyCode press;
    public GameObject FireWorks;
    GameManager GM;
    int pointsClicked = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag == "Cat" && Input.GetKey(press)) 
        {
            Instantiate(FireWorks, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            GM = FindObjectOfType<GameManager>();
            GM.ModifyScore(pointsClicked);
        } 
    }
}
