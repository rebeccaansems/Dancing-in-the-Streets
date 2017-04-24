using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed, cameraSpeedMultiplier;

    private bool cameraIsMoving = false;

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.y > -2 || cameraIsMoving)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x,
                this.transform.position.y + cameraSpeed + (Time.timeSinceLevelLoad * cameraSpeedMultiplier), -10), 0.05f);
            cameraIsMoving = true;
        }
    }
}
