using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : Alive
{

    private bool inRange = false;
    public bool InRange
    {
        get { return inRange; }
        set { inRange = value; }
    }

	// Use this for initialization
	public override void Start () 
	{
		base.Start ();
        Setup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Setup()
    {
        namePlate.gameObject.GetComponent<Canvas>().worldCamera = FileRef.cameraRef;
        namePlate.selectButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        FileRef.playerRef.SetTarget(this);
    }

}
