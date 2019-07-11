using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerTabtarget : MonoBehaviour {

	private List<Transform> nearbyEnemies;
	[SerializeField]
	private Transform player = null;

	private bool hadClosestTargetInCurrentState = false;

	// Use this for initialization
	void Start () 
	{
		nearbyEnemies = new List<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//SortNearbyEnemies ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Alive> () != null) 
		{
			nearbyEnemies.Add (col.GetComponent<Transform>());
            col.GetComponent<Opponent>().InRange = true;
			//Debug.Log ("Adding: " + col.name);
			//Debug.Log ("nearbyEnemies Count: " + nearbyEnemies.Count);
			hadClosestTargetInCurrentState = false;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
        if (col.GetComponent<Alive>() != null)
        {
            nearbyEnemies.Remove(col.GetComponent<Transform>());
            col.GetComponent<Opponent>().InRange = false;
            //Debug.Log("Removing: " + col.name);
            //Debug.Log("nearbyEnemies Count: " + nearbyEnemies.Count);
            hadClosestTargetInCurrentState = false;
        }
	}

	private Transform GetClosestEnemy()
	{
		if (nearbyEnemies.Count == 0) 
		{
			return null;
		}
		Transform closest = nearbyEnemies.Last ();
		foreach (Transform a in nearbyEnemies) 
		{
			float tempDistance = Vector3.Distance (a.position, player.position);
			if(tempDistance < Vector3.Distance (closest.position, player.position))
			{
				closest = a;
			}
		}
		return closest;
	}

	public void TabTarget()
	{
		if (GetClosestEnemy () != null)
		{
			if ((hadClosestTargetInCurrentState == false)&&(player.GetComponent<Alive> ().target != GetClosestEnemy ().GetComponent<Alive> ()))
			{
				player.GetComponent<Alive> ().SetTarget (GetClosestEnemy ().GetComponent<Alive> ());
				hadClosestTargetInCurrentState = true;
			}
			else 
			{
				foreach (Transform t in nearbyEnemies) 
				{
					if (player.GetComponent<Alive> ().target != t.GetComponent<Alive> ()) 
					{
						player.GetComponent<Alive> ().SetTarget (t.GetComponent<Alive> ());
                        nearbyEnemies.Shuffle();
						break;
					}
				}
			}
		}
	}


}
