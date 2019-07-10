using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagement : MonoBehaviour
{
    public Room ParentRoom { get; set; }

    private bool doorsState = true;

    [SerializeField]
    private RoomEnemyManagement enemyManagement;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ActivateRoom()
    {
        //Close doors
        CloseDoors();

        //SpawnEnemies
        enemyManagement.InitializeEnemies();

        RoomGenerator.me.currentEnemiesCount = enemyManagement.EnemyCount;
    }

    public void CloseDoors()
    {
        doorsState = false;
        ParentRoom.rightDoor.Close();
        ParentRoom.leftDoor.Close();
        ParentRoom.topDoor.Close();
        ParentRoom.bottomDoor.Close();
    }

    public void OpenDoors()
    {
        doorsState = true;
        ParentRoom.rightDoor.Open();
        ParentRoom.leftDoor.Open();
        ParentRoom.topDoor.Open();
        ParentRoom.bottomDoor.Open();
    }

    public void SwitchDoors()
    {
        if(doorsState)
        {
            CloseDoors();
        }
        else
        {
            OpenDoors();
        }
    }
}
