﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform enemyHolder;
    public GameObject Manager;
    public GameObject enemyBullet;
    public Transform shootingOffset;
    private Animator animator;

    public float speed;
    public float fireRate = 0.0599f;
    public bool gameIsOver = false;

    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    private void Update()
    {
        if (gameIsOver)
        {
            GameObject.Find("Manager").GetComponent<Manager>().gameOver();
            gameIsOver = false;
        }
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -9 || enemy.position.x > 10)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (Random.value > fireRate)
            {
                Instantiate(enemyBullet, enemy.transform.position, enemy.transform.rotation);
            }
            
        }

        if (enemyHolder.childCount == 2)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.29f);
        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            Debug.Log("Player wins!");
            GameObject.Find("Manager").GetComponent<Manager>().gameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "GrayUFO")
        {
            animator = this.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");
            Debug.Log("Killed Gray UFO");
            Destroy(this.gameObject, 0.4f);
            GameObject.Find("Manager").GetComponent<Manager>().increaseScoreGray();
        }
        else if (gameObject.tag == "RedUFO")
        {
            animator = this.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");
            Destroy(this.gameObject, 0.4f);
            GameObject.Find("Manager").GetComponent<Manager>().increaseScoreRed();
        }
        else if (gameObject.tag == "BlueUFO")
        {
            animator = this.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");
            Destroy(this.gameObject, 0.4f);
            GameObject.Find("Manager").GetComponent<Manager>().increaseScoreBlue();
        }
        else if (gameObject.tag == "PurpleUFO")
        {
            animator = this.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Death");
            Debug.Log("Killed Purple UFO");
            Destroy(this.gameObject,0.4f);
            GameObject.Find("Manager").GetComponent<Manager>().increaseScorePurple();
        }
    }
}