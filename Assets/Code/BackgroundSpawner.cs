using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] floorPieces, wallPieces;
    public GameObject player;
    public bool isWallSpawner;

    private GameObject newFloor, newWall;
    private float currentY = -4;
    private int playerSpawnIndex;
    private List<int> playerSpawnPositions;

    void Start()
    {
        playerSpawnPositions = new List<int>() { 40, 80, 120, 160, 200, 240, 280, 320 };

        if (isWallSpawner)
        {
            SpawnWallBlock(6);
        }
        else
        {
            SpawnFloorBlock(30);
        }
    }

    void Update()
    {
        if ((int)player.transform.position.y % playerSpawnPositions[playerSpawnIndex] == 0
            && (int)player.transform.position.y != 0)
        {
            playerSpawnIndex++;
            if (isWallSpawner)
            {
                SpawnWallBlock(4);
            }
            else
            {
                SpawnFloorBlock(20);
            }
        }
    }

    void SpawnFloorBlock(int repeat)
    {
        for (int i = 0; i < repeat; i++)
        {
            newFloor = Instantiate(floorPieces[Random.Range(0, floorPieces.Length)], this.transform);
            newFloor.transform.position = new Vector2(-2, currentY);

            newFloor = Instantiate(floorPieces[Random.Range(0, floorPieces.Length)], this.transform);
            newFloor.transform.position = new Vector2(0.333f, currentY);

            newFloor = Instantiate(floorPieces[Random.Range(0, floorPieces.Length)], this.transform);
            newFloor.transform.position = new Vector2(2.666f, currentY);

            currentY += 2.25f;
        }
    }

    void SpawnWallBlock(int repeat)
    {
        for (int i = 0; i < repeat; i++)
        {
            newWall = Instantiate(wallPieces[0], this.transform);
            newWall.transform.position = new Vector2(-2.9f, currentY);

            newWall = Instantiate(wallPieces[1], this.transform);
            newWall.transform.position = new Vector2(2.82f, currentY);

            currentY += 12f;
        }
    }
}
