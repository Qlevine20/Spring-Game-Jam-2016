using UnityEngine;
using System.Collections;


public class Dog : Creature {

	private Vector3 targetVector;
	private Vector3 origin;
	public float speed;

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
		return transform.position + (((targetVector-origin)).normalized * speed * Time.deltaTime);
	}
}