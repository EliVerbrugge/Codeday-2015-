using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLogic : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, 5);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
