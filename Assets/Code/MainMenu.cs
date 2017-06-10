using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainCamera, dancerSpawner, groundSpawner, wallSpawner, menuItems, UIheader;

    public bool cameraCanMove = false;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("menuOn") || PlayerPrefs.GetInt("menuOn") == 1)
        {
            mainCamera.GetComponent<Camera>().enabled = false;
            dancerSpawner.SetActive(false);
            groundSpawner.SetActive(false);
            wallSpawner.SetActive(false);
            mainCamera.SetActive(false);
            UIheader.SetActive(false);
        }
        else
        {
            mainCamera.GetComponent<Camera>().enabled = true;
            dancerSpawner.SetActive(true);
            groundSpawner.SetActive(true);
            wallSpawner.SetActive(true);
            mainCamera.SetActive(true);
            UIheader.SetActive(true);
        }
    }

    private void Update()
    {
        if (cameraCanMove)
        {
            UI.isUIOn = true;
            float step = 2 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, mainCamera.transform.position, step);

            if (transform.position == mainCamera.transform.position)
            {
                mainCamera.GetComponent<Camera>().enabled = true;
                groundSpawner.SetActive(true);
                wallSpawner.SetActive(true);
                Destroy(menuItems.gameObject);
                UIheader.SetActive(true);
                UI.isUIOn = false;

                Destroy(this.gameObject);
            }

            if ((int)transform.position.y == mainCamera.transform.position.y - 10)
            {
                dancerSpawner.SetActive(true);
                mainCamera.SetActive(true);
            }
        }
    }
}
