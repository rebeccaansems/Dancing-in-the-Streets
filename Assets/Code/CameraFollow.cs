using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float cameraSpeed, cameraSpeedMultiplier;

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > -2)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x,
                this.transform.position.y + cameraSpeed + (Time.time * cameraSpeedMultiplier), -10), 0.05f);
        }
    }
}
