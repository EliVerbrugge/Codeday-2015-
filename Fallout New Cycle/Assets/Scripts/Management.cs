using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Management : MonoBehaviour {

    public Text enemyText;
    public Text scoreText;
    public Text healthText;
    public Text waveText;
    public Text gameOverText;

    public GameObject thePanel;
    public GameObject introPanel;
    public Button leftButton;
    public Text leftButtonText;
    public Button rightButton;
    public Text rightButtonText;


    public GameObject player;
    public GameObject mover;
    public GameObject bullet;
    public int score = 0;
    public int prevScore = 0;

    bool pressed = false;
    // Use this for initialization

    void Start()
    {
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        enemyText.text = "Enemies: " + GameObject.FindGameObjectsWithTag("Enemy").Length;
        healthText.text = "Health: " + player.GetComponent<Shooting>().health;
            
            waveText.text = "Wave: " + gameObject.GetComponent<WaveManagement>().waveCount;
            scoreText.text = "Score: " + score;
        if (player.GetComponent<Shooting>().health <= 0)
        {
            StartCoroutine(ShowMessage(2));
        }
        if (score % 10 <= 4 && score > prevScore + 5)
        {
            Time.timeScale = 0;
            thePanel.SetActive(true);
            if (score >= 10 && score < 15)
            {
                rightButtonText.text = "+2 Health";
                leftButtonText.text = "+1 Movement Speed";
            }
            if (score >= 20 && score < 25)
            {
                rightButtonText.text = "+5 Health";
                leftButtonText.text = "+2 Movement Speed";
            }
            if (score >= 30 && score < 35)
            {
                rightButtonText.text = "+5 Health";
                leftButtonText.text = "-0.2 Firing Speed";
            }
            if (score >= 40 && score < 45)
            {
                rightButtonText.text = "+2 Damage";
                leftButtonText.text = "+4 Movement Speed";
            }
            waveText.text = "Wave: " + gameObject.GetComponent<WaveManagement>().waveCount;
            scoreText.text = "Score: " + score;
            if (pressed == true)
            {
                Time.timeScale = 1.0f;
                thePanel.SetActive(false);
                pressed = false;
                prevScore = score;
            }
       


        }

    }
    public void pressRight()
    {
        if (score >= 10 && score < 15)
        {
            player.GetComponent<Shooting>().health += 2;
        }
        if (score >= 20 && score < 25)
        {
         
            player.GetComponent<Shooting>().health += 5;

        }
        if (score >= 30 && score < 35)
        {
            player.GetComponent<Shooting>().health += 2;
        }
        if (score >= 40 && score < 45)
        {
            bullet.GetComponent<bulletLogic>().damage += 2;
         
        }
        pressed = true;
    }
    public void pressLeft()
    {
        if (score >= 10 && score < 15)
        {
            mover.GetComponent<Movement>().playerSpeed += 1;
         

        }
        if (score >= 20 && score < 25)
        {
            mover.GetComponent<Movement>().playerSpeed += 2;

          
        }
        if (score >= 30 && score < 35)
        {
            player.GetComponent<Shooting>().fireRate -= 0.2f;
            
        }
        if (score >= 40 && score < 45)
        {
            mover.GetComponent<Movement>().playerSpeed += 4;
        }
        pressed = true;
    }

    public void startPress()
    {
        Time.timeScale = 1;
        introPanel.SetActive(false);
    }
    IEnumerator ShowMessage(int delay)
    {
        gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        gameOverText.gameObject.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }
   
}
