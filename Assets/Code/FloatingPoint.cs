using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPoint : MonoBehaviour
{
    bool didPause = false;

    void Start()
    {
        Destroy(gameObject, this.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            this.GetComponentInChildren<MeshRenderer>().enabled = false;
            didPause = true;
        }
        else if (didPause == true)
        {
            this.GetComponentInChildren<MeshRenderer>().enabled = true;
            didPause = false;
        }
    }
}
