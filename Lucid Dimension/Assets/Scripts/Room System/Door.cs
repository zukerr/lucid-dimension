using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private Direction direction;

    private const float distanceFromWall = 1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == FileRef.playerRef.gameObject)
        {
            //move player to another room
            FileRef.playerRef.gameObject.transform.position = GetSpawnPosition();
            RoomController.rc.focusCamera(transform.parent.GetComponent<Room>().GetAdjacentRoom(direction).gameObject);
            transform.parent.GetComponent<Room>().GetAdjacentRoom(direction).GenerateAdjacent();
        }
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 result = Vector2.zero;
        switch (direction)
        {
            case Direction.right:
                result = new Vector2(transform.position.x + distanceFromWall, transform.position.y);
                break;
            case Direction.left:
                result = new Vector2(transform.position.x - distanceFromWall, transform.position.y);
                break;
            case Direction.top:
                result = new Vector2(transform.position.x, transform.position.y + distanceFromWall);
                break;
            case Direction.bottom:
                result = new Vector2(transform.position.x, transform.position.y - distanceFromWall);
                break;
        }
        return result;
    }

}
