using UnityEngine;
using System.Collections;

public class Dog : Creature {

	public override Vector3 Spawn(){
		return new Vector3(10f,10f,10f);
	}

	public override Vector3 Move(){
		return transform.position;
	}
}
