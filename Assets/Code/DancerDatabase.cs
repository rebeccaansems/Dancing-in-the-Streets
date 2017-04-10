using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerDatabase : MonoBehaviour
{
    [HideInInspector]
    public List<Sprite> armsIn, armsOut;

    public List<Sprite> colorSchemeArmsIn1, colorSchemeArmsOut1;
    public List<Sprite> colorSchemeArmsIn2, colorSchemeArmsOut2;
    public List<Sprite> colorSchemeArmsIn3, colorSchemeArmsOut3;
    public List<Sprite> colorSchemeArmsIn4, colorSchemeArmsOut4;

    private List<List<Sprite>> allColorSchemesArmsIn, allColorSchemesArmsOut;
    // Use this for initialization
    void Awake()
    {
        allColorSchemesArmsIn = new List<List<Sprite>>() { colorSchemeArmsIn1, colorSchemeArmsIn2, colorSchemeArmsIn3, colorSchemeArmsIn4 };
        allColorSchemesArmsOut = new List<List<Sprite>>() { colorSchemeArmsOut1, colorSchemeArmsOut2, colorSchemeArmsOut3, colorSchemeArmsOut4 };

        int index = Random.Range(0, allColorSchemesArmsIn.Count);
        armsIn = new List<Sprite>(allColorSchemesArmsIn[index]);
        armsOut = new List<Sprite>(allColorSchemesArmsOut[index]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
