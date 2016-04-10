﻿using UnityEngine;
using System.Collections;

public class Cat : Creature {


    private Vector3 targetVector;
    private Vector3 origin;
    public float speed;
    public Sprite CatSprite;
    public Sprite DogSprite;
    private bool CaughtDog;
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
        //if (!CaughtDog)
        //{
        if (((targetVector - origin).normalized * speed * Time.deltaTime).x > 0) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
            return transform.position + (((targetVector - origin)).normalized * speed * Time.deltaTime);
       // }
        //float shortestDist = Screen.width - transform.position.x;
        ////((Screen.width - transform.position.x > Screen.width / 2) ? 0 : Screen.width);
        ////((Screen.height - transform.position.y > Screen.height / 2) ? 0 : Screen.height);

        ////if (Screen.height - transform.position.y < shortestDist) 
        ////{
        ////    shortestDist = Screen.height - transform.position.y;
        ////}
        ////if (transform.position.y < Screen.height / 2) 
        ////{
        ////    shortestDist = transform.position.
        ////}
        
        //return transform.position * speed * Time.deltaTime;
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
}
