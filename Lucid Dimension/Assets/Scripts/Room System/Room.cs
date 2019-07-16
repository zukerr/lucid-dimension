using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    right,
    left,
    top,
    bottom
};

public class Room : MonoBehaviour
{

    [SerializeField]
    private bool right;
    [SerializeField]
    private bool left;
    [SerializeField]
    private bool top;
    [SerializeField]
    private bool bottom;

    private GameObject rightRoom = null;
    private GameObject leftRoom = null;
    private GameObject topRoom = null;
    private GameObject bottomRoom = null;

    public Door rightDoor;
    public Door leftDoor;
    public Door topDoor;
    public Door bottomDoor;

    private int xRoomIndex;
    private int yRoomIndex;

    public RoomManagement Management { get; set; }

    public bool Right
    {
        get { return right; }
        set { right = value; }
    }
    public bool Left
    {
        get { return left; }
        set { left = value; }
    }
    public bool Top
    {
        get { return top; }
        set { top = value; }
    }
    public bool Bottom
    {
        get { return bottom; }
        set { bottom = value; }
    }

    public int XRoomIndex
    {
        get
        {
            return xRoomIndex;
        }
    }

    public int YRoomIndex
    {
        get
        {
            return yRoomIndex;
        }
    }

    // Use this for initialization
    void Start ()
    {
        Management = gameObject.GetComponent<RoomManagement>();
        Management.ParentRoom = this;
        if(!RoomGenerator.me.startingRoomCreated)
        {
            RoomGenerator.me.startingRoomCreated = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private Vector2 GetSpawnPosition(Direction dir)
    {
        Vector2 result = Vector2.zero;
        switch(dir)
        {
            case Direction.right:
                result = new Vector2(transform.position.x + (GetComponent<RectTransform>().rect.width * transform.localScale.x), transform.position.y);
                break;
            case Direction.left:
                result = new Vector2(transform.position.x - (GetComponent<RectTransform>().rect.width * transform.localScale.x), transform.position.y);
                break;
            case Direction.top:
                result = new Vector2(transform.position.x, transform.position.y + (GetComponent<RectTransform>().rect.height * transform.localScale.y));
                break;
            case Direction.bottom:
                result = new Vector2(transform.position.x, transform.position.y - (GetComponent<RectTransform>().rect.height * transform.localScale.y));
                break;
        }
        return result;
    }

    public void GenerateAdjacent()
    {
        if ((right)&&(rightRoom == null)&&(RoomGenerator.me.TargetRoomAvailible(xRoomIndex + 1, yRoomIndex)))
        {
            rightRoom = Instantiate(RoomGenerator.me.GetRoomPrefab(), GetSpawnPosition(Direction.right), transform.rotation, transform.parent);
            rightRoom.GetComponent<Room>().leftRoom = gameObject;
            RoomGenerator.me.AddNewRoom(xRoomIndex + 1, yRoomIndex, rightRoom.GetComponent<Room>());
            RandomizeDoorsGeneration(rightRoom);
            rightRoom.GetComponent<Room>().left = true;
            new RoomFixer().DeadEndFix(rightRoom.GetComponent<Room>());
            rightRoom.GetComponent<Room>().Management.SetupDoors();
        }
        if ((left) && (leftRoom == null) && (RoomGenerator.me.TargetRoomAvailible(xRoomIndex - 1, yRoomIndex)))
        {
            leftRoom = Instantiate(RoomGenerator.me.GetRoomPrefab(), GetSpawnPosition(Direction.left), transform.rotation, transform.parent);
            leftRoom.GetComponent<Room>().rightRoom = gameObject;
            RoomGenerator.me.AddNewRoom(xRoomIndex - 1, yRoomIndex, leftRoom.GetComponent<Room>());
            RandomizeDoorsGeneration(leftRoom);
            leftRoom.GetComponent<Room>().right = true;
            new RoomFixer().DeadEndFix(leftRoom.GetComponent<Room>());
            leftRoom.GetComponent<Room>().Management.SetupDoors();
        }
        if ((top) && (topRoom == null) && (RoomGenerator.me.TargetRoomAvailible(xRoomIndex, yRoomIndex + 1)))
        {
            topRoom = Instantiate(RoomGenerator.me.GetRoomPrefab(), GetSpawnPosition(Direction.top), transform.rotation, transform.parent);
            topRoom.GetComponent<Room>().bottomRoom = gameObject;
            RoomGenerator.me.AddNewRoom(xRoomIndex, yRoomIndex + 1, topRoom.GetComponent<Room>());
            RandomizeDoorsGeneration(topRoom);
            topRoom.GetComponent<Room>().bottom = true;
            new RoomFixer().DeadEndFix(topRoom.GetComponent<Room>());
            topRoom.GetComponent<Room>().Management.SetupDoors();
        }
        if ((bottom) && (bottomRoom == null) && (RoomGenerator.me.TargetRoomAvailible(xRoomIndex, yRoomIndex - 1)))
        {
            bottomRoom = Instantiate(RoomGenerator.me.GetRoomPrefab(), GetSpawnPosition(Direction.bottom), transform.rotation, transform.parent);
            bottomRoom.GetComponent<Room>().topRoom = gameObject;
            RoomGenerator.me.AddNewRoom(xRoomIndex, yRoomIndex - 1, bottomRoom.GetComponent<Room>());
            RandomizeDoorsGeneration(bottomRoom);
            bottomRoom.GetComponent<Room>().top = true;
            new RoomFixer().DeadEndFix(bottomRoom.GetComponent<Room>());
            bottomRoom.GetComponent<Room>().Management.SetupDoors();
        }
    }

    private void RandomizeDoorsGeneration(GameObject room)
    {
        room.GetComponent<Room>().Management = room.GetComponent<RoomManagement>();
        room.GetComponent<Room>().Management.ParentRoom = room.GetComponent<Room>();
        room.GetComponent<Room>().Management.RandomizeDoors();
        RoomFixer fixer = new RoomFixer();
        fixer.DoorFix(room.GetComponent<Room>());
    }

    public Room GetAdjacentRoom(Direction dir)
    {
        Room result = null;
        switch (dir)
        {
            case Direction.right:
                result = RoomGenerator.me.GetTargetRoom(xRoomIndex + 1, yRoomIndex); 
                break;
            case Direction.left:
                result = RoomGenerator.me.GetTargetRoom(xRoomIndex - 1, yRoomIndex);
                break;
            case Direction.top:
                result = RoomGenerator.me.GetTargetRoom(xRoomIndex, yRoomIndex + 1);
                break;
            case Direction.bottom:
                result = RoomGenerator.me.GetTargetRoom(xRoomIndex, yRoomIndex - 1);
                break;
        }
        return result;
    }

    public void SetRoomIndex(int x, int y)
    {
        xRoomIndex = x;
        yRoomIndex = y;
    }
}
