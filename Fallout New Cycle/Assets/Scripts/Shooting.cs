using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float maxSpeed = 25f;

    public Rigidbody bullet;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public GameObject manager;

    public int hasKey = 0;
    public int neededKeys = 3;
    public int health = 10;
    public AudioClip SMB;
    public AudioClip Gun;
    public AudioClip Crumple;







    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y, rot.z + 180);
            var instanceBullet = Instantiate(bullet, transform.position, Quaternion.Euler(rot));
            //instanceBullet.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * maxSpeed;
            instanceBullet.GetComponent<Rigidbody>().AddForce(-transform.up.normalized * maxSpeed);
            GetComponent<AudioSource>().PlayOneShot(Gun, 0.7F);


        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= other.GetComponent<enemyLogic>().damage;
        }
        if(other.gameObject.tag == "Flower")
        {
            GetComponent<AudioSource>().PlayOneShot(SMB, 0.7F);
            manager.GetComponent<Management>().score += other.GetComponent<DieQuickly>().scoreToAdd;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Rubbish")
        {
            GetComponent<AudioSource>().PlayOneShot(Crumple, 0.7F);
            hasKey++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Door")
        {
            if(hasKey == neededKeys)
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }


    }


}
