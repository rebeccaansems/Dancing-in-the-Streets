using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<DancerMovement> dancerMovements;
    public List<GameObject> dancerGameObjects;
    public int rotSpeed, moveSpeed;
    public Sprite walkingMan, dancingMan;

    private int currentDancerIndex;
    private bool isFacing;

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = walkingMan;
    }

    // Update is called once per frame
    void Update()
    {
        if (dancerGameObjects.Count > currentDancerIndex)
        {
            Vector3 rotDiff = dancerGameObjects[currentDancerIndex].transform.position - transform.position;
            rotDiff.Normalize();
            float rot_z = Mathf.Atan2(rotDiff.y, rotDiff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            float moveStep = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, dancerGameObjects[currentDancerIndex].transform.position, moveStep);
            GetComponent<SpriteRenderer>().sprite = walkingMan;
            isFacing = false;

            if (Vector3.Distance(transform.position, dancerGameObjects[currentDancerIndex].transform.position) <= 1.15)
            {
                currentDancerIndex++;
            }
        }

        if (dancerGameObjects.Count > 0 && currentDancerIndex != 0)
        {
            dancerMovements[currentDancerIndex - 1].isFacing = isFacing;
            if (!isFacing)
            {
                int difAngles = (int)(this.transform.rotation.eulerAngles.z - dancerGameObjects[currentDancerIndex - 1].transform.rotation.eulerAngles.z);
                if ((difAngles >= 85 && difAngles <= 95) || (difAngles >= -275 && difAngles <= -265))
                {
                    isFacing = true;
                    dancerMovements[currentDancerIndex - 1].isFacing = isFacing;
                }
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = dancingMan;
                transform.RotateAround(dancerGameObjects[currentDancerIndex - 1].transform.position,
                    dancerMovements[currentDancerIndex - 1].spinClockwise ? Vector3.back : Vector3.forward,
                    dancerMovements[currentDancerIndex - 1].spinSpeed * Time.deltaTime);
            }
        }
    }
}
