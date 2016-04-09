using UnityEngine;
using System.Collections;

public class Dog : Creature {

	public override Vector3 Spawn(){
		return UnityEngine.WorldToScreenPoint(new Vector3(Random.Range(0,Screen.width),10f,10f));
	}

	public override Vector3 Move(){
		return transform.position + (new Vector3(-1,-1,0) * Time.deltaTime);
	}
}
