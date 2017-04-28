using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public GameObject floatPoint, floatPointParent;
    public Vector3 dancerLocation;

    public void SpawnPoint(int point)
    {
        GameObject newFloatPoint = Instantiate(floatPoint, floatPointParent.transform);
        newFloatPoint.GetComponent<Text>().text = point.ToString();
        newFloatPoint.transform.position = dancerLocation;
    }
}
