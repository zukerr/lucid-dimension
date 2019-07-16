using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFixer
{
    public void DoorFix(Room room)
    {
        //if room on the right exists
        Room temp = room.GetAdjacentRoom(Direction.right);
        if (temp != null)
        {
            room.Right = temp.Left ? true : false;
        }

        temp = room.GetAdjacentRoom(Direction.left);
        if (temp != null)
        {
            room.Left = temp.Right ? true : false;
        }

        temp = room.GetAdjacentRoom(Direction.top);
        if (temp != null)
        {
            room.Top = temp.Bottom ? true : false;
        }

        temp = room.GetAdjacentRoom(Direction.bottom);
        if (temp != null)
        {
            room.Bottom = temp.Top ? true : false;
        }
    }

    public void DeadEndFix(Room justCreated)
    {
        if(DeadEnd())
        {
            Debug.LogWarning("Dead End Discovered - Fixing!");
            if (!justCreated.Right)
            {
                if(justCreated.GetAdjacentRoom(Direction.right) == null)
                    justCreated.Right = true;
            }
            else if (!justCreated.Left)
            {
                if (justCreated.GetAdjacentRoom(Direction.left) == null)
                    justCreated.Left = true;
            }
            else if (!justCreated.Top)
            {
                if (justCreated.GetAdjacentRoom(Direction.top) == null)
                    justCreated.Top = true;
            }
            else if (!justCreated.Bottom)
            {
                if (justCreated.GetAdjacentRoom(Direction.bottom) == null)
                    justCreated.Bottom = true;
            }
        }
    }

    public bool DeadEnd()
    {
        foreach (Room r in RoomGenerator.me.RoomList)
        {
            if(IsRoomOpen(r))
            {
                return false;
            }
        }
        return true;
    }

    public bool IsRoomOpen(Room room)
    {
        //if room has right door
        if(room.Right)
        {
            //check if there is another room connected to it
            if(room.GetAdjacentRoom(Direction.right) == null)
            {
                return true;
            }
        }
        if (room.Left)
        {
            //check if there is another room connected to it
            if (room.GetAdjacentRoom(Direction.left) == null)
            {
                return true;
            }
        }
        if (room.Top)
        {
            //check if there is another room connected to it
            if (room.GetAdjacentRoom(Direction.top) == null)
            {
                return true;
            }
        }
        if (room.Bottom)
        {
            //check if there is another room connected to it
            if (room.GetAdjacentRoom(Direction.bottom) == null)
            {
                return true;
            }
        }

        return false;
    }

}
