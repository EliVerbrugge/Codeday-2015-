using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnToTrash : MonoBehaviour {

    public GameObject Trash;
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Instantiate(Trash, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
