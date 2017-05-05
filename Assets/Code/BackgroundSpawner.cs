using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject[] wallPieces;
    public GameObject floorPiece, leftWallAccents;
    public Sprite[] floorSprites, leftWallAccentsSprites;
    public GameObject mainCamera;
    public bool isWallSpawner;

    private GameObject newFloor, newWall, newLeftWallAccent;
    private Queue<GameObject> leftWallAccentQueue, wallQueueLeft, wallQueueRight, floorQueue;
    private float currentY = -4, currentLeftY = 0;
    private int playerSpawnPosition = 40;

    void Start()
    {
        leftWallAccentQueue = new Queue<GameObject>();
        wallQueueLeft = new Queue<GameObject>();
        wallQueueRight = new Queue<GameObject>();
        floorQueue = new Queue<GameObject>();

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
        if ((int)mainCamera.transform.position.y % playerSpawnPosition == 0
            && (int)mainCamera.transform.position.y != 0)
        {
            playerSpawnPosition += 40;
            if (isWallSpawner)
            {
                SpawnWallBlock(4);
            }
            else
            {
                SpawnFloorBlock(20);
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

    void SpawnFloorBlock(int repeat)
    {
        for (int i = 0; i < repeat; i++)
        {
            newFloor = Instantiate(floorPiece, this.transform);
            newFloor.transform.position = new Vector2(-2, currentY);
            newFloor.GetComponent<SpriteRenderer>().sprite = floorSprites[Random.Range(0, floorSprites.Length)];
            floorQueue.Enqueue(newFloor);

            newFloor = Instantiate(floorPiece, this.transform);
            newFloor.transform.position = new Vector2(0.333f, currentY);
            newFloor.GetComponent<SpriteRenderer>().sprite = floorSprites[Random.Range(0, floorSprites.Length)];
            floorQueue.Enqueue(newFloor);

            newFloor = Instantiate(floorPiece, this.transform);
            newFloor.transform.position = new Vector2(2.666f, currentY);
            newFloor.GetComponent<SpriteRenderer>().sprite = floorSprites[Random.Range(0, floorSprites.Length)];
            floorQueue.Enqueue(newFloor);

            currentY += 2.25f;
        }
    }

    void SpawnWallBlock(int repeat)
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

        for (int i = 0; i < repeat*2.5f; i++)
        {
            if (Random.Range(0, 10) > 7)
            {
                newLeftWallAccent = Instantiate(leftWallAccents, this.transform);
                newLeftWallAccent.GetComponent<SpriteRenderer>().sprite = leftWallAccentsSprites[Random.Range(0, leftWallAccentsSprites.Length)];
                newLeftWallAccent.transform.position = new Vector2(-2.85f, currentLeftY);
                leftWallAccentQueue.Enqueue(newLeftWallAccent);
                currentLeftY += 4;
            }
            currentLeftY += 4;
        }
    }
}
