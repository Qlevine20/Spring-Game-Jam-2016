using UnityEngine;
using System.Collections;

public class MouseTracker : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
	}
}
