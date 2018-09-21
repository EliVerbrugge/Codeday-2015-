﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(-angle, -Vector3.forward);
    }
}
