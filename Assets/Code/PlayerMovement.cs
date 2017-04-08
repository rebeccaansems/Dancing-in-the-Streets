using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public List<Vector3> playerPositions;
    public int rotSpeed, moveSpeed;

    private int currentPlayerPosition;
    private bool turnTowards;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPositions.Count > currentPlayerPosition)
        {
            Vector3 rotDiff = playerPositions[currentPlayerPosition] - transform.position;
            rotDiff.Normalize();
            float rot_z = Mathf.Atan2(rotDiff.y, rotDiff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            float moveStep = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerPositions[currentPlayerPosition], moveStep);

            if(transform.position == playerPositions[currentPlayerPosition])
            {
                currentPlayerPosition++;
            }
        }
    }
}
