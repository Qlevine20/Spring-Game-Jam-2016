using UnityEngine;
using System.Collections;

public class Animal_Mover : MonoBehaviour {

    public float animal_xSpeed;
    public float animal_ySpeed;
    private float animal_xDirection;
    private float animal_yDirection;
    public float animal_randomize;
    private float chance_to_rotate;
    private float animal_timer;
    public bool isStraight = false;

    // Use this for initialization
    void Start () {

        //animal_xSpeed = Random.Range(1.0f, 3.0f);
        //animal_ySpeed = Random.Range(0.0f, 1.0f);
        Vector2 Direction = setDirection();
        animal_xDirection = Direction.x;
        animal_yDirection = Direction.y;
        animal_timer = 0.0f;
        animal_randomize = 3.0f;
    }
	
	// Update is called once per frame
	void Update () {
        animal_timer += Time.deltaTime;
        if (animal_timer >= animal_randomize && !isStraight)
        {
            animal_timer = 0.0f;
            Vector2 Direction = setDirection();
            animal_xDirection = Direction.x;
            animal_yDirection = Direction.y;
        }

        transform.Translate(animal_xDirection * Time.deltaTime * animal_xSpeed, animal_yDirection * Time.deltaTime * animal_ySpeed, 0.0f);
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Boundary")
        {
            Debug.Log("Exiting");
            setDirection();
        }
    }

    Vector2 setDirection()
    {
        Vector2 dir = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        if (transform.position.x >= 0.0)
        {
            dir.x *= -1;
        }

        if (transform.position.y >= 0.0)
        {
            dir.y *= -1;
        }

        return dir;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animal_xDirection *= -1;
        animal_yDirection *= -1;
    }
    
}
