using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private int speed;
    private bool spinClockwise;

    // Use this for initialization
    void Start()
    {
        transform.localRotation = new Quaternion(0, 0, Random.Range(0, 359), 0);
        speed = Random.Range(75, 300);
        spinClockwise = Random.Range(0, 2) == 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinClockwise ? Vector3.back : Vector3.forward, speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        playerMovement.playerPositions.Add(this.transform.position);
    }

}
