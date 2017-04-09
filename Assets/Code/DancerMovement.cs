using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerMovement : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    public Sprite armsIn, armsOut;
    public bool isFacing;

    public int spinSpeed;
    public bool spinClockwise;

    // Use this for initialization
    void Start()
    {
        transform.localRotation = new Quaternion(0, 0, Random.Range(0, 359), 0);
        spinSpeed = Random.Range(75, 300);
        spinClockwise = Random.Range(0, 2) == 0;
        GetComponent<SpriteRenderer>().sprite = armsIn;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinClockwise ? Vector3.back : Vector3.forward, spinSpeed * Time.deltaTime);

        if (isFacing)
        {
            GetComponent<SpriteRenderer>().sprite = armsOut;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = armsIn;
        }
    }

    private void OnMouseDown()
    {
        if (playerMovement.dancerGameObjects.Count != 0 && playerMovement.dancerGameObjects[playerMovement.dancerGameObjects.Count - 1] != this.gameObject)
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
