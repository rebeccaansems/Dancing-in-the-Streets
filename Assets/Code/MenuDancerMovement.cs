using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDancerMovement : MonoBehaviour
{
    public MainMenu mainMenu;
    public int spinSpeed;
    public bool spinClockwise, isPlayButton;

    private int spriteIndex;
    private bool isVisible;

    void Start()
    {
        transform.localRotation = new Quaternion(0, 0, Random.Range(0, 359), 0);
        if (isPlayButton)
        {
            spinSpeed = 50;
        }
        else
        {
            spinSpeed = Random.Range(150, 400);
        }
        spinClockwise = Random.Range(0, 2) == 0;
    }

    void Update()
    {
        if (isVisible)
        {
            transform.Rotate(spinClockwise ? Vector3.back : Vector3.forward, spinSpeed * Time.deltaTime);
        }

        if (isPlayButton && Input.GetMouseButtonDown(0) && !mainMenu.cameraCanMove)
        {
            mainMenu.cameraCanMove = true;
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        if (isVisible)
        {
            Destroy(this.gameObject);
        }
        isVisible = false;
    }
}
