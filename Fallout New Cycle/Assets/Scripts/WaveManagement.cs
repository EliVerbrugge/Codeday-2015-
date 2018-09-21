using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagement : MonoBehaviour {

    public int waveCount = 0;
    public GameObject enemySmall;
    public GameObject oilBoss;
    public GameObject paperStack;
	// Use this for initialization
	void Start () {
        createEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		if(checkForEnemies() == false)
        {
            waveCount++;
            createEnemies();
        }
	}

    bool checkForEnemies()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void createEnemies()
    {
        for (int i = 2 + waveCount/2; i >0; i--)
        {
            Instantiate(enemySmall, new Vector3(i * 2.0f-10, 0, -13), Quaternion.identity);
        }
        if(waveCount > 3)
        {
            for (int i = waveCount/3; i > 0; i--)
            {
                Instantiate(oilBoss, new Vector3(i * 2.0f - 10, 0, -13), Quaternion.identity);
            }
        }
        if (waveCount > 8)
        {
            for (int i = waveCount / 4 -1; i > 0; i--)
            {
                Instantiate(paperStack, new Vector3(i * 2.0f - 10, 0, -13), Quaternion.identity);
            }
        }
    }
}
