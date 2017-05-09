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

        firstDancer.GetComponent<DancerMovement>().hasTutorial = true;
        secondDancer.GetComponent<DancerMovement>().hasTutorial = true;

        firstDancer.GetComponent<DancerMovement>().tutorialOn = true;
        secondDancer.GetComponent<DancerMovement>().tutorialOn = false;
    }

    private void Start()
    {
        firstDancer.GetComponent<DancerMovement>().spinSpeed = 150;
        secondDancer.GetComponent<DancerMovement>().spinSpeed = 150;
    }

    void Update()
    { 
        if (player.GetComponent<PlayerMovement>().isCircling&& dancingFirst == false && dancingSecond == false && completedFirst == false && completedSecond == false && playerNotCircling)
        {
            secondDancer.GetComponent<DancerMovement>().tutorialOn = true;

            dancingFirst = true;
        }
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == true && dancingSecond == false && completedFirst == false && completedSecond == false && !playerNotCircling)
        {
            firstDancer.GetComponent<DancerMovement>().tutorialOn = false;

            dancingFirst = false;
            completedFirst = true;
        }
        else if (player.GetComponent<PlayerMovement>().isCircling && dancingFirst == false && dancingSecond == false && completedFirst == true && completedSecond == false && playerNotCircling)
        {
            dancingSecond = true;
        }
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == false && dancingSecond == true && completedFirst == true && completedSecond == false && !playerNotCircling)
        {
            secondDancer.GetComponent<DancerMovement>().tutorialOn = false;

            completedSecond = true;
        }
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == false && dancingSecond == false && completedFirst == false && completedSecond == false && playerNotCircling)
        {
            firstDancer.GetComponent<DancerMovement>().tutorialOn = false;
            secondDancer.GetComponent<DancerMovement>().tutorialOn = true;

            dancingFirst = true;
        }
        else if(!player.GetComponent<PlayerMovement>().isConnected && dancingFirst == true && dancingSecond == false && completedFirst == false && completedSecond == false && playerNotCircling)
        {
            dancingFirst = false;
            completedFirst = true;
        }
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == false && dancingSecond == false && completedFirst == true && completedSecond == false && playerNotCircling)
        {
            firstDancer.GetComponent<DancerMovement>().tutorialOn = false;
            secondDancer.GetComponent<DancerMovement>().tutorialOn = false;

            completedSecond = true;
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