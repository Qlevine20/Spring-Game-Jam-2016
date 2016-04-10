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
            if (other.GetComponent<Cat>().Type == "RoarCat") 
            {
                pointsClicked = 200;
            }
            if (other.GetComponent<Cat>().Type == "InvisCat") 
            {
                pointsClicked = 150;
            }

            GameObject child = other.transform.GetChild(0).transform.gameObject;
            child.transform.parent = null;
            child.GetComponent<BoxCollider2D>().enabled = true;
            child.GetComponent<Dog>().Caught = false;
            Instantiate(FireWorks, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            GM = FindObjectOfType<GameManager>();
            GM.ModifyScore(pointsClicked);
        } 
    }
}
