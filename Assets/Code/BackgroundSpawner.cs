using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] wallPieces;
    public GameObject floorPiece, leftWallAccents;
    public Sprite[] floorSpritesLvl1, floorSpritesLvl2, floorSpritesLvl3, floorSpritesLvl4, floorSpritesLvl5, floorSpritesLvl6, leftWallAccentsSprites;
    public GameObject mainCamera;
    public bool isWallSpawner;

    private GameObject newFloor, newWall, newLeftWallAccent;
    private Queue<GameObject> leftWallAccentQueue, wallQueueLeft, wallQueueRight, floorQueue;
    private Sprite[] currentFloor;
    private float currentY = -4, currentLeftY = 60;
    private int playerSpawnPosition = 40;

    void Start()
    {
        leftWallAccentQueue = new Queue<GameObject>();
        wallQueueLeft = new Queue<GameObject>();
        wallQueueRight = new Queue<GameObject>();
        floorQueue = new Queue<GameObject>();

        if (isWallSpawner)
        {
            SpawnWallBlock(6, 0);
        }
        else
        {
            SpawnFloorBlock(30, 0);
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
                SpawnWallBlock(4, (int)mainCamera.transform.position.y % playerSpawnPosition);
            }
            else
            {
                SpawnFloorBlock(20, (int)mainCamera.transform.position.y % playerSpawnPosition);
            }
        }

        if (leftWallAccentQueue.Count != 0 && mainCamera.transform.position.y - 9 > leftWallAccentQueue.Peek().transform.position.y)
        {
            Destroy(leftWallAccentQueue.Dequeue().gameObject);
        }

        if (wallQueueLeft.Count != 0 && mainCamera.transform.position.y - 15 > wallQueueLeft.Peek().transform.position.y)
        {
            Destroy(wallQueueLeft.Dequeue().gameObject);
            Destroy(wallQueueRight.Dequeue().gameObject);
        }

        if (floorQueue.Count != 0 && mainCamera.transform.position.y - 9 > floorQueue.Peek().transform.position.y)
        {
            Destroy(floorQueue.Dequeue().gameObject);
            Destroy(floorQueue.Dequeue().gameObject);
            Destroy(floorQueue.Dequeue().gameObject);
        }

    }

    void SpawnFloorBlock(int repeat, int level)
    {
        if (level > 40 * 12)
        {
            currentFloor = floorSpritesLvl6;
        }
        else if (level > 40 * 9)
        {
            currentFloor = floorSpritesLvl5;
        }
        else if (level > 40 * 8)
        {
            currentFloor = floorSpritesLvl4;
        }
        else if (level > 40 * 6)
        {
            currentFloor = floorSpritesLvl3;
        }
        else if (level > 40 * 4)
        {
            currentFloor = floorSpritesLvl1;
        }
        else if (level > 40 * 2)
        {
            currentFloor = floorSpritesLvl2;
        }
        else
        {
            currentFloor = floorSpritesLvl1;
        }

        for (int i = 0; i < repeat; i++)
        {
            newFloor = Instantiate(floorPiece, this.transform);
            newFloor.transform.position = new Vector2(-2, currentY);
            newFloor.GetComponent<SpriteRenderer>().sprite = currentFloor[Random.Range(0, currentFloor.Length)];
            floorQueue.Enqueue(newFloor);

            newFloor = Instantiate(floorPiece, this.transform);
            newFloor.transform.position = new Vector2(0.333f, currentY);
            newFloor.GetComponent<SpriteRenderer>().sprite = currentFloor[Random.Range(0, currentFloor.Length)];
            floorQueue.Enqueue(newFloor);

            newFloor = Instantiate(floorPiece, this.transform);
            newFloor.transform.position = new Vector2(2.666f, currentY);
            newFloor.GetComponent<SpriteRenderer>().sprite = currentFloor[Random.Range(0, currentFloor.Length)];
            floorQueue.Enqueue(newFloor);

            currentY += 2.25f;
        }
    }

    void SpawnWallBlock(int repeat, int level)
    {
        for (int i = 0; i < repeat; i++)
        {
            newWall = Instantiate(wallPieces[0], this.transform);
            newWall.transform.position = new Vector2(-2.9f, currentY);
            wallQueueLeft.Enqueue(newWall);

            newWall = Instantiate(wallPieces[1], this.transform);
            newWall.transform.position = new Vector2(2.82f, currentY);
            wallQueueRight.Enqueue(newWall);

            currentY += 12f;
        }

        if (level > 3)
        {
            for (int i = 0; i < repeat * 2.5f; i++)
            {
                if (Random.Range(0, 10) > 3)
                {
                    newLeftWallAccent = Instantiate(leftWallAccents, this.transform);
                    newLeftWallAccent.GetComponent<SpriteRenderer>().sprite = leftWallAccentsSprites[Random.Range(0, leftWallAccentsSprites.Length)];
                    newLeftWallAccent.transform.position = new Vector2(-2.85f, currentLeftY);
                    leftWallAccentQueue.Enqueue(newLeftWallAccent);
                }
                currentLeftY += 4;
            }
        }
    }
}
