using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerDatabase : MonoBehaviour
{
    [HideInInspector]
    public List<Sprite> armsIn, armsOut;
    public List<Texture2D> textures;

    private List<List<Sprite>> allColorSchemesArmsIn, allColorSchemesArmsOut;

    void Awake()
    {
        allColorSchemesArmsIn = new List<List<Sprite>>();
        allColorSchemesArmsOut = new List<List<Sprite>>();

        for (int j = 0; j < textures.Count; j++)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(textures[j].name);
            List<Sprite> armsIn = new List<Sprite>();
            List<Sprite> armsOut = new List<Sprite>();
            for (int i = 0; i < sprites.Length / 2; i++)
            {
                armsOut.Add(sprites[i]);
            }
            for (int i = sprites.Length / 2; i < sprites.Length; i++)
            {
                armsIn.Add(sprites[i]);
            }
            allColorSchemesArmsIn.Add(armsIn);
            allColorSchemesArmsOut.Add(armsOut);
        }

        int index = Random.Range(0, allColorSchemesArmsIn.Count);
        armsIn = new List<Sprite>(allColorSchemesArmsIn[index]);
        armsOut = new List<Sprite>(allColorSchemesArmsOut[index]);
    }
}
