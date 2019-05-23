using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Creator {

    public static void CreateEnemy(GameObject enemy,Room room,Vector3 localPosition)
    {
        Vector3 position = new Vector3(Mathf.Clamp(localPosition.x, -7, 7),Mathf.Clamp(localPosition.y, -7, 7));
        Object.Instantiate(enemy, room.transform.position+position, Quaternion.identity);
    }
    public static void CreateEnemy(GameObject enemy, Room room)
    {
        Object.Instantiate(enemy, room.transform.position, Quaternion.identity);
    }
}
