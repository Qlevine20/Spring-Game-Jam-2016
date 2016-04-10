using UnityEngine;
using System.Collections;


public class WallDog : Creature {

	public override Vector3 Spawn(){

		return Camera.main.ScreenToWorldPoint(new Vector3(
			Random.Range(5, Screen.width-5),
			Random.Range(5, Screen.height-5),
			Camera.main.nearClipPlane*100));
	}

	public override Vector3 Move(){
		Vector3 cam = Camera.main.WorldToScreenPoint(transform.position);
		float[] values = new float[] {cam.x, cam.y, Screen.width - cam.x, Screen.height - cam.y};
		var min = Min(values);

		return transform.position + 
				((min == values[0])? Vector3.left :
				(min == values[1])? Vector3.down :
				(min == values[2])? Vector3.right : Vector3.up);
	}
	
	private float Min(float a, float b){ float f = ((Mathf.Abs(a) < Mathf.Abs(b))? a : b); Debug.Log(a+" : " +b + " = " +f); return f; }

	private float Min(float[] a){
		var min = a[a.Length-1];

		for(var i = a.Length-1; i >= 0; i--){
			min = Min(min, a[i]);
		}
		return min;
	}
	
}