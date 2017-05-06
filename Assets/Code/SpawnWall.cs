using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    public GameObject wall, wallAccent;
    public GameObject[] baseWalls, baseAccents;
    public Sprite[] wallSprites, wallAccentSprites;

    private GameObject newWall, newWallAccent;
    private List<GameObject> wallList, wallAccentList;
    private float currentWallY, currentWallAccentY;

    void Start()
    {
        wallList = new List<GameObject>();
        wallAccentList = new List<GameObject>();

        for (int i = 0; i < baseWalls.Length; i++)
        {
            wallList.Add(baseWalls[i]);
        }
        currentWallY = wallList[wallList.Count - 1].transform.position.y;

        for (int i = 0; i < baseAccents.Length; i++)
        {
            wallAccentList.Add(baseAccents[i]);
        }
        currentWallAccentY = wallAccentList[wallAccentList.Count - 1].transform.position.y;
    }

    private void Update()
    {
        if (wallList.Count != 0)
        {
            if (Camera.main.transform.position.y - 2 > wallList[wallList.Count - 1].transform.position.y)
            {
                Spawn();
            }

            if (Camera.main.transform.position.y - 30 > wallList[0].transform.position.y)
            {
                Destroy(wallList[0].gameObject);
                wallList.RemoveAt(0);
                Destroy(wallList[0].gameObject);
                wallList.RemoveAt(0);
            }
        }

        if (wallAccentList.Count != 0)
        {
            if (Camera.main.transform.position.y + 6 > wallAccentList[wallAccentList.Count - 1].transform.position.y)
            {
                SpawnAccent();
            }

            if (Camera.main.transform.position.y - 9 > wallAccentList[0].transform.position.y)
            {
                Destroy(wallAccentList[0].gameObject);
                wallAccentList.RemoveAt(0);
            }
        }
    }

    void Spawn()
    {
        currentWallY += 17.77f;

        newWall = Instantiate(wall, this.transform);
        newWall.transform.position = new Vector2(-3.1f, currentWallY);
        newWall.GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(0, wallSprites.Length / 2)];
        wallList.Add(newWall);

        newWall = Instantiate(wall, this.transform);
        newWall.transform.position = new Vector2(3.1f, currentWallY);
        newWall.GetComponent<SpriteRenderer>().sprite = wallSprites[Random.Range(wallSprites.Length / 2, wallSprites.Length)];
        wallList.Add(newWall);
    }

    void SpawnAccent()
    {
        currentWallAccentY += 4;

        if (Random.Range(0, 10) > 5)
        {
            if (Random.Range(0, 2) == 1)
            {
                newWallAccent = Instantiate(wallAccent, this.transform);
                newWallAccent.transform.position = new Vector2(-2.8f, currentWallAccentY);
                newWallAccent.GetComponent<SpriteRenderer>().sprite = wallAccentSprites[Random.Range(0, wallAccentSprites.Length / 2)];

                wallAccentList.Add(newWallAccent);
            }
            else
            {
                newWallAccent = Instantiate(wallAccent, this.transform);
                newWallAccent.transform.position = new Vector2(2.8f, currentWallAccentY);
                newWallAccent.GetComponent<SpriteRenderer>().sprite = wallAccentSprites[Random.Range(wallAccentSprites.Length / 2, wallAccentSprites.Length)];

                wallAccentList.Add(newWallAccent);
            }
        }
    }
}
