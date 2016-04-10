using UnityEngine;
using System.Collections;


public class Dog : Creature {

	private Vector3 targetVector;
	private Vector3 origin;
	public float speed;
    public bool Caught = false;
    AudioSource DogFX;
    float delay;
    private int dir = 1;

    public override void Start()
    {
        Physics2D.IgnoreLayerCollision(8,8);
        //base.Start();
        delay = Random.Range(0.0f, 4.0f);
        DogFX = GetComponent<AudioSource>();
    }

    public override void Update()
    {
        base.Update();
        delay += Time.deltaTime;
        if (!DogFX.isPlaying && delay >= 12.0f)
        {
            DogFX.Play();
            delay = Random.Range(0.0f, 4.0f);
        }
        if (!Caught)
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime * dir), transform.position.y, transform.position.z);
        }
    }

    public override Vector3 Spawn(){
		var side = Random.Range(0,3);
		var width = Random.Range(0,Screen.width);
		var height = Random.Range(0,Screen.height);

		var result = Camera.main.ScreenToWorldPoint(new Vector3(
			(side%2 == 0)? width : ((width%2)*Screen.width),
			(side%2 == 1)? height : ((height%2)*Screen.height),
			Camera.main.nearClipPlane*100));

		targetVector = Camera.main.ScreenToWorldPoint(new Vector3(
			width-result.x,
			height-result.y,
			Camera.main.nearClipPlane*100));

		origin = result;

		return result;
	}

	public override Vector3 Move(){

        if (!Caught)
        {
            if (((targetVector - origin).normalized * speed * Time.deltaTime).x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            return transform.position + (((targetVector - origin)).normalized * speed * Time.deltaTime);
        }
        return transform.position;
	}

    public void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "wall") 
        {
            dir *= -1;
        }
    }
}
