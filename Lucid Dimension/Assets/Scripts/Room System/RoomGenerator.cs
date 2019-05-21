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

	// Use this for initialization
	void Start ()
    {
        me = this;
        roomTab = new Room[1000, 1000];
        roomTab[500, 500] = startingRoom;
        startingRoom.SetRoomIndex(500, 500);
        startingRoom.GenerateAdjacent();
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