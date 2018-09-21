using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public int playerSpeed = 10;
    // Update is called once per frame
    public int minX = 0;
    public int maxX = 0;
    public int minY = 0;
    public int maxY = 0;


    void Update () {
       
        moveForward();
    }

   
    void moveForward()
    {
        if(Input.GetKey("w"))
        {
            transform.Translate(0, playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("s"))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey("a"))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))//Press up arrow key to move forward on the Y AXIS
        {
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }

    
}
