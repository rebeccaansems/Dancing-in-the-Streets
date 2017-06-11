using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Stack<GameObject> dancerGameObjectStack, previousDancerGameObjectStack;
    public Sprite walkingMan, dancingMan;
    public UI UiControls;

    public int rotSpeed, moveSpeed, numPairings;
    public bool isConnected, isCircling, isHitting;

    private GameObject currentDancer;
    private int walkingIntoPlace = 0;

    void Start()
    {
        dancerGameObjectStack = new Stack<GameObject>();
        previousDancerGameObjectStack = new Stack<GameObject>();
        GetComponent<SpriteRenderer>().sprite = walkingMan;
    }

    void Update()
    {
        if(!(!PlayerPrefs.HasKey("menuOn") || PlayerPrefs.GetInt("menuOn") == 1))
        {
            walkingIntoPlace = 2;
        }

        if (walkingIntoPlace == 1)
        {
            float step = 2.5f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -4f), step);
            if(transform.position == new Vector3(0, -4f))
            {
                var direction = new Vector3(0,0,0) - transform.position;

                direction.y = 0;
                direction.x = 0;

                var rot = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(
                                                 transform.rotation,
                                                 rot,
                                                 200 * Time.deltaTime);
                if(transform.rotation == new Quaternion(0, 0, 0, 1))
                {
                    walkingIntoPlace = 2;
                }
            }
        }
        else if (walkingIntoPlace == 2)
        {
            if (dancerGameObjectStack.Count != 0 && Camera.main != null)
            {
                currentDancer = null;
                Vector3 rotDiff = dancerGameObjectStack.Peek().transform.position - transform.position;
                rotDiff.Normalize();
                float rot_z = Mathf.Atan2(rotDiff.y, rotDiff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

                float moveStep = (moveSpeed + (Camera.main.transform.position.y / 50)) * Time.deltaTime;
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
                        GetComponent<Audio>().PlaySuccessAudio();
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
    }

    void OnBecameInvisible()
    {
        this.GetComponent<Leaderboard>().AddScore(this.GetComponent<PlayerScoring>().score);
        this.GetComponent<Leaderboard>().AddPairings(numPairings);
        UiControls.PlayerDied();
    }

    public void WalkIntoMainScreen()
    {
        walkingIntoPlace = 1;
    }
}
