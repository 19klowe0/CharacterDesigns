﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private float dazedTime;
    public float startDazedTime;

    public GameObject bloodEffect;
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
        //anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        //take damage
        
        if(health <= 0)
        {
            Die();
        }
        //move
        transform.Translate(Vector2.left * speed * Time.deltaTime);
     
        
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage Taken");
    }

    void Die()
    {
        Destroy(gameObject);

        //disable enemy 
        //this.enabled = false;
        //GetComponent<Collider2D>().enabled = false;
    }
}
