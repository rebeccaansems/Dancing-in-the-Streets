using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public GameObject floatPoint, floatPointParent;
    public Vector3 dancerLocation;

    public void SpawnPoint(int point)
    {
        GameObject newFloatPoint = Instantiate(floatPoint, floatPointParent.transform);
        newFloatPoint.GetComponentInChildren<TextMesh>().text = point.ToString();
        newFloatPoint.transform.position = dancerLocation;
        if(point < 0)
        {
            newFloatPoint.GetComponentInChildren<TextMesh>().color = new Color32(237, 45, 61, 255);
        }
    }
}
