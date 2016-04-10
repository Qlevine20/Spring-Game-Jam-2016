using UnityEngine;
using System.Collections;

public class Cat : Creature {


    private Vector3 targetVector;
    private Vector3 origin;
    public float speed;
    public Sprite CatSprite;
    public Sprite DogSprite;
    private bool CaughtDog =false;
    bool isSpotted = false;
    GameManager GM;
    int pointsRevealed = 50;

    public override void Update()
    {
        base.Update();
        if (GetComponent<GazeAwareComponent>().HasGaze)
        {
            Debug.Log("Found");
            GetComponent<SpriteRenderer>().sprite = CatSprite;
            GetComponent<Animator>().SetBool("Seen", true);
            if (!isSpotted)
            {
                GM = FindObjectOfType<GameManager>();
                GM.ModifyScore(pointsRevealed);
                isSpotted = true;
            }
        }       
    }

    public override Vector3 Spawn()
    {
        var side = Random.Range(0, 3);
        var width = Random.Range(0, Screen.width);
        var height = Random.Range(0, Screen.height);

        var result = Camera.main.ScreenToWorldPoint(new Vector3(
            (side % 2 == 0) ? width : ((width % 2) * Screen.width),
            (side % 2 == 1) ? height : ((height % 2) * Screen.height),
            Camera.main.nearClipPlane * 100));

        targetVector = Camera.main.ScreenToWorldPoint(new Vector3(
            width - result.x,
            height - result.y,
            Camera.main.nearClipPlane * 100));

        origin = result;

        return result;
    }

    public override Vector3 Move()
    {
        if (((targetVector - origin).normalized * speed * Time.deltaTime).x > 0) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
            return transform.position + (((targetVector - origin)).normalized * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Dog" && !CaughtDog) 
        {
            Debug.Log("Caught");
            CaughtDog = true;
            other.collider.enabled = false;
            GetComponent<Collider2D>().isTrigger = true;
            other.transform.parent = transform;
            other.gameObject.GetComponent<Dog>().Caught = true;
            GetComponent<SpriteRenderer>().sprite = CatSprite;
            GetComponent<Animator>().SetBool("Seen", true);
        }

    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Boundary" && CaughtDog)
        {
            GM = FindObjectOfType<GameManager>();
            GM.ModifyLives(1);
        }
    }
}
