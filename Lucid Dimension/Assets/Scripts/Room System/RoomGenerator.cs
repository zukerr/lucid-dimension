using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    [SerializeField]
    private Room startingRoom;

    [SerializeField]
    private GameObject basicRoomPrefab;

    public static RoomGenerator me;

    private Room[,] roomTab;
    private List<Room> roomList;

    public int currentEnemiesCount;

    public Room activeRoom;
    public bool startingRoomCreated = false;

    public List<Room> RoomList
    {
        get { return roomList; }
    }

	// Use this for initialization
	void Start ()
    {
        me = this;
        roomList = new List<Room>();
        roomTab = new Room[1000, 1000];
        //roomTab[500, 500] = startingRoom;
        //startingRoom.SetRoomIndex(500, 500);
        AddNewRoom(500, 500, startingRoom);
        startingRoom.GenerateAdjacent();
        StartCoroutine(GameStart());
        activeRoom = startingRoom;
	}

    public void EnemyDied()
    {
        currentEnemiesCount--;
        if(currentEnemiesCount == 0)
        {
            activeRoom.Management.OpenDoors();
            //Room Complete - player gets a reward
        }
    }

    public void SetActiveRoom(Room room)
    {
        activeRoom = room;
        activeRoom.Management.ActivateRoom();
    }

    private IEnumerator GameStart()
    {
        while(startingRoom.Management == null)
        {
            yield return null;
        }
        startingRoom.Management.SetupDoors();
        startingRoom.Management.ActivateRoom();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public GameObject GetRoomPrefab()
    {
        return basicRoomPrefab;
    }

    public void AddNewRoom(int x, int y, Room room)
    {
        if(TargetRoomAvailible(x, y))
        {
            roomList.Add(room);
            roomTab[x, y] = room;
            room.SetRoomIndex(x, y);
        }
    }

    public Room GetTargetRoom(int x, int y)
    {
        return roomTab[x, y] != null ? roomTab[x, y] : null;
    }

    public bool TargetRoomAvailible(int x, int y)
    {
        return roomTab[x, y] != null ? false : true;
    }
}
