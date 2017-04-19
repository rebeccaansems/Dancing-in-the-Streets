using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Stack<GameObject> dancerGameObjectStack, previousDancerGameObjectStack;
    public Sprite walkingMan, dancingMan;
    public int rotSpeed, moveSpeed;
    public bool isConnected, isCircling, isHitting;

    private GameObject currentDancer;

    // Use this for initialization
    void Start()
    {
        dancerGameObjectStack = new Stack<GameObject>();
        previousDancerGameObjectStack = new Stack<GameObject>();
        GetComponent<SpriteRenderer>().sprite = walkingMan;
    }

    // Update is called once per frame
    void Update()
    {
        if (dancerGameObjectStack.Count != 0)
        {
            currentDancer = null;
            Vector3 rotDiff = dancerGameObjectStack.Peek().transform.position - transform.position;
            rotDiff.Normalize();
            float rot_z = Mathf.Atan2(rotDiff.y, rotDiff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            float moveStep = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, dancerGameObjectStack.Peek().transform.position, moveStep);
            GetComponent<SpriteRenderer>().sprite = walkingMan;
            isConnected = false;

            if (Vector3.Distance(transform.position, dancerGameObjectStack.Peek().transform.position) <= 1.05)
            {
                previousDancerGameObjectStack.Push(dancerGameObjectStack.Peek());
                currentDancer = dancerGameObjectStack.Pop();
            }
            else
            {
                isCircling = false;
            }
        }

        if (currentDancer != null)
        {
            if (!isConnected)
            {
                int difAngles = (int)(this.transform.rotation.eulerAngles.z - currentDancer.transform.rotation.eulerAngles.z) + 90;
                if ((difAngles >= 77 && difAngles <= 103) || (difAngles >= -283 && difAngles <= -257))
                {
                    isConnected = true;
                }
                else
                {
                    isCircling = true;

                    transform.RotateAround(currentDancer.transform.position,
                        currentDancer.GetComponent<DancerMovement>().spinClockwise ? Vector3.forward : Vector3.back,
                        (currentDancer.GetComponent<DancerMovement>().spinSpeed * Time.deltaTime) / 4f);
                }
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = dancingMan;
                transform.RotateAround(currentDancer.transform.position,
                    currentDancer.GetComponent<DancerMovement>().spinClockwise ? Vector3.back : Vector3.forward,
                    currentDancer.GetComponent<DancerMovement>().spinSpeed * Time.deltaTime);
            }
        }
    }
}
