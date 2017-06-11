using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDancerMovement : MonoBehaviour
{
    public MainMenu mainMenu;
    public int spinSpeed;
    public bool spinClockwise, isPlayButton;
    public GameObject player;

    private bool isVisible;

    void Start()
    {
        PlayerPrefs.GetInt("menuOn");
        if (!PlayerPrefs.HasKey("menuOn") || PlayerPrefs.GetInt("menuOn") == 1)
        {
            if (!isPlayButton)
            {
                transform.localRotation = new Quaternion(0, 0, Random.Range(0, 359), 0);
                spinSpeed = Random.Range(150, 400);
                spinClockwise = Random.Range(0, 2) == 0;
            }
            else
            {
                player.transform.position = new Vector3(-3f, -4f, 0);
                player.transform.rotation = Quaternion.Euler(0f, 0f,-90);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (isVisible)
        {
            transform.Rotate(spinClockwise ? Vector3.back : Vector3.forward, spinSpeed * Time.deltaTime);
        }
    }

    public void PlayButtonPressed()
    {
        if (!mainMenu.cameraCanMove)
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
