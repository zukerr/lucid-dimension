using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

    [SerializeField]
    private CameraController cameraController;
    [SerializeField]
    private GameObject cameraBounds;

    public static RoomController rc;
	// Use this for initialization
	void Awake ()
    {
        rc = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void focusCamera(GameObject room)
    {
        cameraController.CamTarget = room.transform;
        cameraBounds.transform.position = room.transform.position;
    }
}
