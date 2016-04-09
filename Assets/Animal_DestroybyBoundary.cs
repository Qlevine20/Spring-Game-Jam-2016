using UnityEngine;
using System.Collections;

public class Animal_DestroybyBoundary : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("out");

        Destroy(other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Inside");
    }
}
