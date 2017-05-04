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
}
