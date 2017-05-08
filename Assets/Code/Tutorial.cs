using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject player;

    private GameObject firstDancer, secondDancer;
    private bool dancingFirst = false, dancingSecond = false, completedFirst = false, completedSecond = false, playerNotCircling = true;

    void Awake()
    {
        player = GameObject.Find("Player");
        firstDancer = this.transform.GetChild(0).GetChild(0).gameObject;
        secondDancer = this.transform.GetChild(0).GetChild(1).gameObject;

        firstDancer.GetComponent<DancerMovement>().spinSpeed = 75;
        secondDancer.GetComponent<DancerMovement>().spinSpeed = 75;

        firstDancer.GetComponent<DancerMovement>().hasTutorial = true;
        secondDancer.GetComponent<DancerMovement>().hasTutorial = true;

        firstDancer.GetComponent<DancerMovement>().tutorialOn = true;
        secondDancer.GetComponent<DancerMovement>().tutorialOn = false;
    }

    void Update()
    { 
        if (player.GetComponent<PlayerMovement>().isCircling&& dancingFirst == false && dancingSecond == false && completedFirst == false && completedSecond == false && playerNotCircling)
        {
            secondDancer.GetComponent<DancerMovement>().tutorialOn = true;
            dancingFirst = true;
            Debug.Log(1);
        }
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == true && dancingSecond == false && completedFirst == false && completedSecond == false && !playerNotCircling)
        {
            firstDancer.GetComponent<DancerMovement>().tutorialOn = false;
            dancingFirst = false;
            completedFirst = true;
            Debug.Log(2);
        }
        else if (player.GetComponent<PlayerMovement>().isCircling && dancingFirst == false && dancingSecond == false && completedFirst == true && completedSecond == false && playerNotCircling)
        {
            Debug.Log(3);
            dancingSecond = true;
        }
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == false && dancingSecond == true && completedFirst == true && completedSecond == false && !playerNotCircling)
        {
            secondDancer.GetComponent<DancerMovement>().tutorialOn = false;
            completedSecond = true;
            Debug.Log(4);
        }

        if (player.GetComponent<PlayerMovement>().isCircling)
        {
            playerNotCircling = false;
        }
        else
        {
            playerNotCircling = true;
        }
    }
}