using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;
    public GameObject[] baseGround;
    public Sprite[] groundSprites;
    public int[] groundChangeLevels;

    private GameObject newGround;
    private List<GameObject> groundList;
    private int currentLevel;
    private float currentGroundY;

    private void Start()
    {
        groundList = new List<GameObject>();

        for (int i = 0; i < baseGround.Length; i++)
        {
            groundList.Add(baseGround[i]);
        }
        currentGroundY = groundList[groundList.Count - 1].transform.position.y;
    }

    private void Update()
    {
        if (Camera.main.transform.position.y + 4 > groundList[groundList.Count - 1].transform.position.y)
        {
            Spawn();
        }

        if (Camera.main.transform.position.y > groundChangeLevels[currentLevel])
        {
            currentLevel++;
        }

        if (Camera.main.transform.position.y - 8 > groundList[0].transform.position.y)
        {
            Destroy(groundList[0].gameObject);
            groundList.RemoveAt(0);
            Destroy(groundList[0].gameObject);
            groundList.RemoveAt(0);
            Destroy(groundList[0].gameObject);
            groundList.RemoveAt(0);
        }
    }

    private void Spawn()
    {
        newGround = Instantiate(ground, this.transform);
        newGround.transform.position = new Vector2(-2, currentGroundY);
        newGround.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(currentLevel * 3, currentLevel * 3 + 3)];
        groundList.Add(newGround);

        newGround = Instantiate(ground, this.transform);
        newGround.transform.position = new Vector2(0.333f, currentGroundY);
        newGround.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(currentLevel * 3, currentLevel * 3 + 3)];
        groundList.Add(newGround);

        newGround = Instantiate(ground, this.transform);
        newGround.transform.position = new Vector2(2.666f, currentGroundY);
        newGround.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(currentLevel * 3, currentLevel * 3 + 3)];
        groundList.Add(newGround);

        currentGroundY += 2.25f;
    }
}
