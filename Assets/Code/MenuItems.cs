using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItems : MonoBehaviour {
    
	void Start () {
        if (!(!PlayerPrefs.HasKey("menuOn") || PlayerPrefs.GetInt("menuOn") == 1))
        {
            Destroy(this.gameObject);
        }
    }
}
