using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public Transform[] positionPlayer = new Transform[4];
    private int index;
    public GameObject giftIndicator;
    private bool playerState = false;
    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = positionPlayer[index].position;
    }

    // Update is called once per frame
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

    }
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Cadeau") && !playerState)
            {
                playerState = true;
                giftIndicator.SetActive(true);
            }

            if (other.gameObject.CompareTag("Box"))
            {
                Debug.Log("Je rentre dans le chest");
            }

            if (other.gameObject.CompareTag("Box") && playerState)
            {   
                giftIndicator.SetActive(false);
                score++;
                playerState=!playerState;
                
            }

        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("On rentre dans le chest"+ col.gameObject.name);
        }
}
