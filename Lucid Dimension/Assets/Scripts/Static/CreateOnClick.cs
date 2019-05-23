using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnClick : MonoBehaviour {

    public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Creator.CreateEnemy(enemy,RoomGenerator.me.GetTargetRoom(500,500),new Vector3(-10,10));
        }
	}
}
