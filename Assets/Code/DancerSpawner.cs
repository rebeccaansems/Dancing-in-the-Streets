using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerSpawner : MonoBehaviour
{
    public List<GameObject> dancerGroups;
    public GameObject player;

    private int lastYValue, playerSpawnLocation = 40;
    private GameObject newDancerGroup;

    // Use this for initialization
    void Awake()
    {
        lastYValue = 0;
        SpawnBlock(8);
    }

    // Update is called once per frame
    void Update()
    {
        if ((int)player.transform.position.y % playerSpawnLocation == 0
            && (int)player.transform.position.y != 0)
        {
            playerSpawnLocation += 40;
            SpawnBlock(5);
        }
    }

    void SpawnBlock(int loop)
    {
        for (int i = 0; i < loop; i++)
        {
            newDancerGroup = Instantiate(dancerGroups[Random.Range(0, dancerGroups.Count)]);
            newDancerGroup.transform.position = new Vector3(0, lastYValue, 0);
            lastYValue += 8;

        }
    }
}
