using UnityEngine;
using System.Collections;

public class Animal_DestroybyBoundary : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {

        Destroy(other.gameObject);
    }
}
