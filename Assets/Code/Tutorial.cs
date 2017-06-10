using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject player;

    private GameObject firstDancer, secondDancer;
    private bool dancingFirst = false, dancingSecond = false, completedFirst = false, completedSecond = false, playerNotCircling = true;

    void Start()
    {
        if (PlayerPrefs.GetInt("tutorialsOn") == 1)
        {
            player = GameObject.Find("Player");
            firstDancer = this.transform.GetChild(0).GetChild(0).gameObject;
            secondDancer = this.transform.GetChild(0).GetChild(1).gameObject;

            firstDancer.GetComponent<DancerMovement>().hasTutorial = true;
            secondDancer.GetComponent<DancerMovement>().hasTutorial = true;

            firstDancer.GetComponent<DancerMovement>().tutorialOn = true;
            secondDancer.GetComponent<DancerMovement>().tutorialOn = false;

            firstDancer.GetComponent<DancerMovement>().spinSpeed = 150;
            secondDancer.GetComponent<DancerMovement>().spinSpeed = 150;
        }
        else
        {
            Destroy(GetComponent<Tutorial>());
        }
    }

    void Update()
    {
        //player is circling dancer 1
        if (player.GetComponent<PlayerMovement>().isCircling && dancingFirst == false && dancingSecond == false && completedFirst == false && completedSecond == false && playerNotCircling)
        {
            firstDancer.GetComponent<DancerMovement>().tutorialOn = false;

            dancingFirst = true;
        }
        //player is connected with dancer 1
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == true && dancingSecond == false && completedFirst == false && completedSecond == false && !playerNotCircling)
        {
            secondDancer.GetComponent<DancerMovement>().tutorialOn = true;
            dancingFirst = false;
            completedFirst = true;
        }
        //player is circling dancer 2
        else if (player.GetComponent<PlayerMovement>().isCircling && dancingFirst == false && dancingSecond == false && completedFirst == true && completedSecond == false && playerNotCircling)
        {
            secondDancer.GetComponent<DancerMovement>().tutorialOn = false;
            dancingSecond = true;
        }
        //player is connected with dancer 2
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == false && dancingSecond == true && completedFirst == true && completedSecond == false && !playerNotCircling)
        {
            completedSecond = true;
        }
        //player is connected with dancer 1 without circling first
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == false && dancingSecond == false && completedFirst == false && completedSecond == false && playerNotCircling)
        {
            firstDancer.GetComponent<DancerMovement>().tutorialOn = false;
            secondDancer.GetComponent<DancerMovement>().tutorialOn = true;

            dancingFirst = true;
        }
        //player is walking between dancer 1 and dancer 2
        else if (!player.GetComponent<PlayerMovement>().isConnected && dancingFirst == true && dancingSecond == false && completedFirst == false && completedSecond == false && playerNotCircling)
        {
            dancingFirst = false;
            completedFirst = true;
        }
        //player is connected with dancer 2 without circling first
        else if (player.GetComponent<PlayerMovement>().isConnected && dancingFirst == false && dancingSecond == false && completedFirst == true && completedSecond == false && playerNotCircling)
        {
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