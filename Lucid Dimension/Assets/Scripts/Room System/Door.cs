using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField]
    private Direction direction;

    private Room myRoom;

    private const float distanceFromWall = 1f;

    private Vector2 normalColliderOffset;
    private Vector2 normalColliderSize;

    private Vector2 lockedColliderOffset;
    private Vector2 lockedColliderSize;

    private BoxCollider2D myCollider;

	// Use this for initialization
	void Start ()
    {
        myRoom = gameObject.transform.parent.GetComponent<Room>();
        myCollider = GetComponent<BoxCollider2D>();
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
            RoomGenerator.me.SetActiveRoom(transform.parent.GetComponent<Room>().GetAdjacentRoom(direction));
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

    public void Setup()
    {
        myRoom = gameObject.transform.parent.GetComponent<Room>();
        bool temp = true;
        SetupLockedColliders();
        switch (direction)
        {
            case Direction.right:
                temp = myRoom.Right;
                break;
            case Direction.left:
                temp = myRoom.Left;
                break;
            case Direction.top:
                temp = myRoom.Top;
                break;
            case Direction.bottom:
                temp = myRoom.Bottom;
                break;
        }
        if(!temp)
        {
            myCollider.isTrigger = false;
            myCollider.offset = lockedColliderOffset;
            myCollider.size = lockedColliderSize;
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(this);
        }
    }

    private void SetupLockedColliders()
    {
        myCollider = GetComponent<BoxCollider2D>();
        normalColliderOffset = myCollider.offset;
        normalColliderSize = myCollider.size;

        switch (direction)
        {
            case Direction.right:
                lockedColliderOffset = new Vector2(-0.005f, 0f);
                lockedColliderSize = new Vector2(0.02069518f, 0.1f);
                break;
            case Direction.left:
                lockedColliderOffset = new Vector2(0.005f, 0f);
                lockedColliderSize = new Vector2(0.02069518f, 0.1f);
                break;
            case Direction.top:
                lockedColliderOffset = new Vector2(0f, -0.007f);
                lockedColliderSize = new Vector2(0.1f, 0.02069518f);
                break;
            case Direction.bottom:
                lockedColliderOffset = new Vector2(0f, 0.005f);
                lockedColliderSize = new Vector2(0.1f, 0.02069518f);
                break;
        }
    }

    public void Close()
    {
        if(myCollider == null)
        {
            myCollider = GetComponent<BoxCollider2D>();
        }
        myCollider.isTrigger = false;
        myCollider.offset = lockedColliderOffset;
        myCollider.size = lockedColliderSize;
        if(this != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }

        //Display locked door graphic
    }

    public void Open()
    {
        if(this != null)
        {
            myCollider = GetComponent<BoxCollider2D>();
            myCollider.isTrigger = true;
            myCollider.offset = normalColliderOffset;
            myCollider.size = normalColliderSize;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        
        //stop displaying locked door graphic
    }
}
