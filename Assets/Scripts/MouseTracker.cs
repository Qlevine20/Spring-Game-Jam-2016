﻿using UnityEngine;
using System.Collections;

public class MouseTracker : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 1.0f;
    public GameObject FireWorks;
    GameManager GM;
    int pointsClicked = 100;
    // Use this for initialization
    void Start ()
    {
        //GM = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition;
        mousePosition.z = 30.0f;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Cat") 
        {
            Debug.Log("Found");
            if (Input.GetMouseButtonDown(0)) 
            {
                Debug.Log("Destroy");
                Instantiate(FireWorks, transform.position, Quaternion.identity);
                if (other.transform.childCount > 0) 
                {
                    GameObject child = other.transform.GetChild(0).transform.gameObject;
                    child.transform.parent = null;
                    child.GetComponent<Dog>().Caught = false;

                }
                Destroy(other.gameObject);
                GM = FindObjectOfType<GameManager>();
                GM.ModifyScore(pointsClicked);
            }
        }
    }
}
