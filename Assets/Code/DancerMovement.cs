using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerMovement : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    public DancerDatabase danceDatabase;
    public Sprite armsIn, armsOut;
    public bool isFacing;

    public int spinSpeed;
    public bool spinClockwise;

    private int spriteIndex;

    // Use this for initialization
    void Start()
    {
        transform.localRotation = new Quaternion(0, 0, Random.Range(0, 359), 0);
        spinSpeed = Random.Range(75, 300);
        spinClockwise = Random.Range(0, 2) == 0;
        spriteIndex = Random.Range(0, danceDatabase.armsIn.Count);
        GetComponent<SpriteRenderer>().sprite = danceDatabase.armsIn[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinClockwise ? Vector3.back : Vector3.forward, spinSpeed * Time.deltaTime);

        if (isFacing)
        {
            GetComponent<SpriteRenderer>().sprite = danceDatabase.armsOut[spriteIndex];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = danceDatabase.armsIn[spriteIndex];
        }
    }

    private void OnMouseDown()
    {
        if (playerMovement.dancerGameObjects.Count != 0 && 
            playerMovement.dancerGameObjects[playerMovement.dancerGameObjects.Count - 1] != this.gameObject &&
            playerMovement.isFacing)
        {
            playerMovement.dancerMovements.Add(this);
            playerMovement.dancerGameObjects.Add(this.gameObject);
        }
        else if (playerMovement.dancerGameObjects.Count == 0)
        {
            playerMovement.dancerMovements.Add(this);
            playerMovement.dancerGameObjects.Add(this.gameObject);
        }
    }

}
