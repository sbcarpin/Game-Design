using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * Resources:
 * Character Detection from tag on trigger enter
 * https://answers.unity.com/questions/334962/character-detection-from-tag-on-trigger-enter.html
 * Delay
 * https://forum.unity.com/threads/delay-ontriggerenter.389932/ 
 * Player lives script
 * https://answers.unity.com/questions/780220/player-lives-script.html
 */

public class GameManag : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public GameObject powerIndicator;
    //particle
    public ParticleSystem explosion;
    public ParticleSystem killEn;
    //audio sounds
    public AudioClip crashSound;
    public AudioClip enemyKillSound;
    public AudioClip powerSound;
    private AudioSource playerAudio;
    //text boxes 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI noEnterText;
    public bool hasPowerUp = false;
    public bool isGameActive;
    //to keep track of player lives
    public int playerLives;
    //to keep track of tokens/gems got
    public int gemCount;
    
    //public Transform playerShip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        //Instantiate(playerShip, gameObject.transform.position, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
        noEnterText.gameObject.SetActive(false);
        //isGameActive = true;
        //make text boxes show lives and gem count
        gemCount = 0;
        playerLives = 3;
        scoreText.text = "Gems: " + gemCount;
        livesText.text = "Lives: " + playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        powerIndicator.transform.position = transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasPowerUp)
        {
            //checking how many lives the player has left
            if (playerLives > 0)
            {
                explosion.Play();
                playerAudio.PlayOneShot(crashSound, 1);

                //playerLives--;
                updateLives();
                //Instantiate(playerShip, gameObject.transform.position, Quaternion.identity);
                player = GameObject.FindGameObjectWithTag("Player");

            }
            else
            {
                GameOver();
                explosion.Play();
                playerAudio.PlayOneShot(crashSound, 1);
                //used to destory the player
                //StartCoroutine(Delay());
            }
        }
        //if there is a power up you can destroy enemy
        else if (other.CompareTag("Enemy") && hasPowerUp)
        {
            //Rigidbody enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            killEn.Play();
            playerAudio.PlayOneShot(enemyKillSound, 1.0f);
            Destroy(other.gameObject);
        }
        //when you encounter a super power 
        else if(other.tag == "Friendly")
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(powerSound, 1.0f);
            powerIndicator.gameObject.SetActive(true);
            //reference the other class to change speed
            PlayerControl.movementSpeed = 15f;
            StartCoroutine(PowerupCountdown());
        }
        //when you encounter a gem/token
        else if (other.tag == "Token")
        {
            playerAudio.PlayOneShot(powerSound, 1.0f);
            //gemCount++;
            updateScore();
            Destroy(other.gameObject);
        }
    }

    /*
     * will only work if other object is not a trigger */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !hasPowerUp)
        {
            //checking how many lives the player has left
            if (playerLives > 0)
            {
                explosion.Play();
                playerAudio.PlayOneShot(crashSound, 1.0f);

                updateLives();
                //playerLives--;
                //Instantiate(playerShip, gameObject.transform.position, Quaternion.identity);
                player = GameObject.FindGameObjectWithTag("Player");

            }
            else
            {
                GameOver();
                explosion.Play();
                playerAudio.PlayOneShot(crashSound, 1.0f);
                //used to destory the player
                //StartCoroutine(Delay());
            }
        }
        //if there is a power up you can destroy enemy
        else if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            //Rigidbody enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            killEn.Play();
            playerAudio.PlayOneShot(enemyKillSound, 1.0f);
            Destroy(collision.gameObject);
            //Debug.Log("Collided");
        }
        //tries to open the gate too soon 
        else if (collision.gameObject.CompareTag("gate") && gemCount < 20)
        {
            noEnterText.gameObject.SetActive(true);
            StartCoroutine(GateDelay());
        }
        //collected all 20 gems and opens gate
        else if (collision.gameObject.CompareTag("gate") && gemCount >= 20)
        {
            killEn.Play();
            playerAudio.PlayOneShot(powerSound, 1.0f);
            Destroy(collision.gameObject);
        }
        //when player has completed 20 gems and open the gate pass to winning scene
        //touches the end floor 
        else if(collision.gameObject.CompareTag("Yay") && gemCount == 20)
        {
            SceneManager.LoadScene("Congrats");
        }
    }

    //timer for the superpower
    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(10f);
        hasPowerUp = false;
        powerIndicator.gameObject.SetActive(false);
        PlayerControl.movementSpeed = 7.0f;
    }

    //delays a 0.5 seconds so the the particle affect can play
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(30);
        //Destroy(gameObject);
    }

    //delay for trying to open gate early
    IEnumerator GateDelay()
    {
        yield return new WaitForSeconds(5f);
        noEnterText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        //gameOverText.gameObject.SetActive(true);
        //isGameActive = false;
        StartCoroutine(Delay());
        SceneManager.LoadScene("GameOver");
    }

    public void updateScore()
    {
        gemCount++;
        scoreText.text = "Gems: " + gemCount;
    }

    public void updateLives()
    {
        playerLives--;
        livesText.text = "Lives: " + playerLives;
    }

}
