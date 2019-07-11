using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDoor
{
    private RoomManagement rm;

    public RandomDoor(RoomManagement rm)
    {
        this.rm = rm;
    }

    private bool ParseBinaryToBoolean(int inpt)
    {
        if (inpt == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int[] DecimalToBinary(int dec)
    {
        int[] temp = new int[4];
        int[] result = new int[4];
        int i;
        for (i = 0; dec > 0; i++)
        {
            temp[i] = dec % 2;
            dec = dec / 2;
        }
        int j = 0;
        for (i = i - 1; i >= 0; i--)
        {
            result[j] = temp[i];
            j++;
        }
        return result;
    }

    public void SetupDoorBooleans()
    {
        int rng = Random.Range(0, 16);
        int[] tab = DecimalToBinary(rng);
        rm.ParentRoom.Right = ParseBinaryToBoolean(tab[0]);
        rm.ParentRoom.Left = ParseBinaryToBoolean(tab[1]);
        rm.ParentRoom.Top = ParseBinaryToBoolean(tab[2]);
        rm.ParentRoom.Bottom = ParseBinaryToBoolean(tab[3]);
    }
}
