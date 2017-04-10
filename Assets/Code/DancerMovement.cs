using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerMovement : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    public DancerDatabase danceDatabase;
    public Sprite armsIn, armsOut;

    public int spinSpeed;
    public bool spinClockwise;

    private int spriteIndex;
    private bool isVisible;

    // Use this for initialization
    void Start()
    { 
        danceDatabase = GameObject.Find("Dancer Spawner").GetComponent<DancerDatabase>();
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();

        transform.localRotation = new Quaternion(0, 0, Random.Range(0, 359), 0);
        spinSpeed = Random.Range(75, 300);
        spinClockwise = Random.Range(0, 2) == 0;
        spriteIndex = Random.Range(0, danceDatabase.armsIn.Count);
        GetComponent<SpriteRenderer>().sprite = danceDatabase.armsIn[spriteIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (isVisible)
        {
            transform.Rotate(spinClockwise ? Vector3.back : Vector3.forward, spinSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.transform.position) <= 1.05)
            {
                GetComponent<SpriteRenderer>().sprite = danceDatabase.armsOut[spriteIndex];
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = danceDatabase.armsIn[spriteIndex];
            }
        }

        if(player.transform.position.y > this.transform.position.y + 20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (playerMovement.dancerGameObjectQueue.Count != 0 &&
            playerMovement.dancerGameObjectQueue.Peek() != this.gameObject &&
            playerMovement.isFacing)
        {
            playerMovement.dancerGameObjectQueue.Enqueue(this.gameObject);
        }
        else if (playerMovement.dancerGameObjectQueue.Count == 0)
        {
            playerMovement.dancerGameObjectQueue.Enqueue(this.gameObject);
        }
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
