using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    public Transform[] positionPlayer = new Transform[4];
    private int index;
    public GameObject giftIndicator;
    private bool playerState = false;
    public int score=0;
    public GameObject victoryMessage;
    public float playerTimer = 5f;
    public GameObject lossMessage;
    public Text _scoreText;
    public Text TimerMachine;
    void Start()
    {
        transform.position = positionPlayer[index].position;
    }

   
    void Update()
    {
        if (index > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                index--;
                transform.position = positionPlayer[index].position;
            }

        }

        if (index < 3)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {index++;
            transform.position = positionPlayer[index].position; 
            }
        }
        
        if (index==3 && playerState)
        {
            score++;
            giftIndicator.SetActive(false);
            playerState = !playerState;
        }

        if (score == 5)
        {
            Time.timeScale = 0;
            victoryMessage.SetActive(true);
        }

        playerTimer -= Time.deltaTime;
        if (playerTimer <= 0f)
        {
            Time.timeScale = 0;
            lossMessage.SetActive(true);
        }

        _scoreText.text = "Score = "+score;
        TimerMachine.text = "Time left =" + playerTimer;

    }
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Cadeau") && !playerState)
            {
                playerState = true;
                giftIndicator.SetActive(true);
            }

        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("On rentre dans le chest"+ col.gameObject.name);
        }
}
