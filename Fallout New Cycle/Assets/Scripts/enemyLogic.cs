using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLogic : MonoBehaviour
{

    public int health = 1;



    public Transform Player;
    public Transform Flower;
    public int speed = 1;
    public int damage = 1;
    public float maxDis = 7;








    void Update()
    {
        if (health <= 0)
        {
            Instantiate(Flower, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Player = GameObject.FindWithTag("Player").transform;
        //rotate to look at the player
        Vector3 dir = Player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.LookAt(Player.position);
        // transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, Player.position) > 0.5f && Vector3.Distance(transform.position, Player.position) < maxDis)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            health -= other.GetComponent<bulletLogic>().damage;
        }
    }
}