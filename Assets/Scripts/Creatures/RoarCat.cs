using UnityEngine;
using System.Collections;

public class RoarCat : Cat {


    public float TimeToRoar = 2;
    private float counter = 0;
    public GameObject FireWorks;
    private bool Shouted = false;

    public override void Update() 
    {
        base.Update();
        counter += Time.deltaTime;

        if (counter > TimeToRoar && !Shouted) 
        {
            Shouted = true;
            GameObject[] Spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach(GameObject Spawner in Spawners)
            {
                Instantiate(FireWorks, transform.position, Quaternion.identity);
                if (Spawner.GetComponent<Animal_Spawner>().interval > 1.5f)
                {
                    Spawner.GetComponent<Animal_Spawner>().interval *= .9f;
                }
            }
            
        }
    }
	// Use this for initialization
	
	// Update is called once per frame
}
