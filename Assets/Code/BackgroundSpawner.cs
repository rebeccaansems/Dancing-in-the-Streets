using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] floorPieces, wallPieces;
    public GameObject mainCamera;
    public bool isWallSpawner;

    private GameObject newFloor, newWall;
    private float currentY = -4;
    private int playerSpawnPosition = 40;

    void Start()
    {
        if (isWallSpawner)
        {
            SpawnWallBlock(6, false);
        }
        else
        {
            SpawnFloorBlock(30, false);
        }
    }

    void Update()
    {
        if ((int)mainCamera.transform.position.y % playerSpawnPosition == 0
            && (int)mainCamera.transform.position.y != 0)
        {
            playerSpawnPosition += 40;
            if (isWallSpawner)
            {
                SpawnWallBlock(4, true);
            }
            else
            {
                SpawnFloorBlock(20, true);
            }
        }
    }

    void SpawnFloorBlock(int repeat, bool destroy)
    {
        for (int i = 0; i < repeat; i++)
        {
            if (destroy)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            newFloor = Instantiate(floorPieces[Random.Range(0, floorPieces.Length)], this.transform);
            newFloor.transform.position = new Vector2(-2, currentY);

            newFloor = Instantiate(floorPieces[Random.Range(0, floorPieces.Length)], this.transform);
            newFloor.transform.position = new Vector2(0.333f, currentY);

            newFloor = Instantiate(floorPieces[Random.Range(0, floorPieces.Length)], this.transform);
            newFloor.transform.position = new Vector2(2.666f, currentY);

            currentY += 2.25f;
        }

        if (destroy)
        {
            for (int i = 0; i < repeat * 1.5; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    void SpawnWallBlock(int repeat, bool destroy)
    {
        for (int i = 0; i < repeat; i++)
        {
            newWall = Instantiate(wallPieces[0], this.transform);
            newWall.transform.position = new Vector2(-2.9f, currentY);

            newWall = Instantiate(wallPieces[1], this.transform);
            newWall.transform.position = new Vector2(2.82f, currentY);

            currentY += 12f;
        }

        if (destroy)
        {
            for (int i = 0; i < repeat * 1.5; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
