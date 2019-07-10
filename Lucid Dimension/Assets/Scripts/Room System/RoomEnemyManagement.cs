using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemyManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private int enemyCount = 3;

    public int EnemyCount
    {
        get { return enemyCount; }
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void InitializeEnemies()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            //Randomize spawnpoint, then spawn
            Instantiate(enemyPrefab, GenerateRandomSpawnpoint(), transform.rotation, transform);
        }
    }

    private Vector3 GenerateRandomSpawnpoint()
    {
        RectTransform temp = GetComponent<RectTransform>();
        float halfWidth = temp.rect.width / 2 * temp.localScale.x;
        float halfHeight = temp.rect.height / 2 * temp.localScale.y;

        Vector2 lowerLeft = new Vector2(temp.position.x - halfWidth, temp.position.y - halfHeight);
        Vector2 upperRight = new Vector2(temp.position.x + halfWidth, temp.position.y + halfHeight);

        float randomX = Random.Range(lowerLeft.x, upperRight.x);
        float randomY = Random.Range(lowerLeft.y, upperRight.y);

        return new Vector3(randomX, randomY, 0);
    }
}
