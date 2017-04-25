using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerSpawner : MonoBehaviour
{
    public List<GameObject> dancerGroups;
    public GameObject camera;

    private int lastYValue, playerSpawnLocation = 40;
    private GameObject newDancerGroup;
    
    void Awake()
    {
        lastYValue = 0;
        SpawnBlock(8);
    }

    void Update()
    {
        if ((int)camera.transform.position.y % playerSpawnLocation == 0
            && (int)camera.transform.position.y != 0)
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
