﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerMovement : MonoBehaviour
{
    public GameObject mainCamera, player, tutorialCircle, tutorialPointer;
    public PlayerMovement playerMovement;
    public DancerDatabase danceDatabase;
    public Sprite armsIn, armsOut;

    public int spinSpeed, minSpinSpeed, maxSpinSpeed;
    public bool spinClockwise, armsAreOut, hasTutorial, tutorialOn = true;

    private GameObject personalTutorialPointer;

    private int spriteIndex;
    private bool isVisible;

    void Start()
    {
        danceDatabase = GameObject.Find("Dancer Spawner").GetComponent<DancerDatabase>();
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("Main Camera");
        playerMovement = player.GetComponent<PlayerMovement>();
        armsAreOut = false;

        transform.localRotation = new Quaternion(0, 0, Random.Range(0, 359), 0);
        spinSpeed = Random.Range((int)mainCamera.transform.position.y + 150, (int)mainCamera.transform.position.y + 400);
        spinClockwise = Random.Range(0, 2) == 0;
        spriteIndex = Random.Range(0, danceDatabase.armsIn.Count);
        GetComponent<SpriteRenderer>().sprite = danceDatabase.armsIn[spriteIndex];

        if (hasTutorial)
        {
            personalTutorialPointer = Instantiate(tutorialPointer);
            personalTutorialPointer.transform.position = this.transform.position + new Vector3(0, 0.75f, 0);
        }
    }

    void Update()
    {
        if (isVisible)
        {
            transform.Rotate(spinClockwise ? Vector3.back : Vector3.forward, spinSpeed * Time.deltaTime);
        }

        if (player.transform.position.y > this.transform.position.y + 20)
        {
            Destroy(this.gameObject);
        }

        if (hasTutorial && tutorialOn)
        {
            personalTutorialPointer.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (hasTutorial)
        {
            personalTutorialPointer.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (!UI.isUIOn)
        {
            if (playerMovement.previousDancerGameObjectStack.Count != 0 &&
                playerMovement.previousDancerGameObjectStack.Peek() != this.gameObject &&
                playerMovement.isConnected)
            {
                playerMovement.dancerGameObjectStack.Push(this.gameObject);
            }
            else if (playerMovement.previousDancerGameObjectStack.Count == 0)
            {
                playerMovement.dancerGameObjectStack.Push(this.gameObject);
            }
        }
    }

    public void ExtendArms()
    {
        GetComponent<SpriteRenderer>().sprite = danceDatabase.armsOut[spriteIndex];
        armsAreOut = true;
    }

    public void RetractArms()
    {
        GetComponent<SpriteRenderer>().sprite = danceDatabase.armsIn[spriteIndex];
        armsAreOut = false;
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        isVisible = false;
    }
}
