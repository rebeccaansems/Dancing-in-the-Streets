using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerSpawner : MonoBehaviour
{
    public GameObject Dancer;

    // Use this for initialization
    void Awake()
    {
        GameObject newDancer;
        float lastYValue = -1;
        for(int i=0; i<50; i++)
        {
            newDancer = Instantiate(Dancer);
            lastYValue += Random.Range(1f, 3f);
            newDancer.transform.position = new Vector3(Random.Range(-1.65f, 1.3f), lastYValue, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
