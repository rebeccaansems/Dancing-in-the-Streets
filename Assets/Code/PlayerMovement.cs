using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Stack<GameObject> dancerGameObjectStack, previousDancerGameObjectStack;
    public Sprite walkingMan, dancingMan;
    public UI UiControls;

    public int rotSpeed, moveSpeed, numPairings;
    public bool isConnected, isCircling, isHitting;

    private GameObject currentDancer;

    void Start()
    {
        dancerGameObjectStack = new Stack<GameObject>();
        previousDancerGameObjectStack = new Stack<GameObject>();
        GetComponent<SpriteRenderer>().sprite = walkingMan;
    }

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

            if (GetComponent<SpriteRenderer>().sprite != walkingMan)
            {
                GetComponent<SpriteRenderer>().sprite = walkingMan;
            }
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
            this.GetComponent<PlayerScoring>().pMan.dancerLocation = currentDancer.transform.position;
            if (!isConnected)
            {
                int difAngles = (int)(this.transform.rotation.eulerAngles.z - currentDancer.transform.rotation.eulerAngles.z) + 90;
                if ((difAngles >= 77 && difAngles <= 103) || (difAngles >= -283 && difAngles <= -257))
                {
                    currentDancer.GetComponent<DancerMovement>().ExtendArms();
                    GetComponent<SpriteRenderer>().sprite = dancingMan;
                    isConnected = true;
                    numPairings++;
                }
                else
                {
                    isCircling = true;
                    currentDancer.GetComponent<DancerMovement>().RetractArms();

                    transform.RotateAround(currentDancer.transform.position,
                        currentDancer.GetComponent<DancerMovement>().spinClockwise ? Vector3.forward : Vector3.back,
                        (currentDancer.GetComponent<DancerMovement>().spinSpeed * Time.deltaTime) / 4f);
                }
            }
            else
            {
                transform.RotateAround(currentDancer.transform.position,
                    currentDancer.GetComponent<DancerMovement>().spinClockwise ? Vector3.back : Vector3.forward,
                    currentDancer.GetComponent<DancerMovement>().spinSpeed * Time.deltaTime);
            }
        }

        if (previousDancerGameObjectStack.Count != 0 && previousDancerGameObjectStack.Peek().GetComponent<DancerMovement>().armsAreOut && !isConnected)
        {
            previousDancerGameObjectStack.Peek().GetComponent<DancerMovement>().RetractArms();
        }
    }

    void OnBecameInvisible()
    {
        this.GetComponent<Leaderboard>().AddScore(this.GetComponent<PlayerScoring>().score);
        this.GetComponent<Leaderboard>().AddPairings(numPairings);
        UiControls.PlayerDied();
    }
}
