using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieQuickly : MonoBehaviour {

    public int TimeTillDeath;
    public int scoreToAdd = 0;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, TimeTillDeath);
	}
	

}
