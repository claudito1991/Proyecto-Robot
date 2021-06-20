﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDies : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageReceived = 10;

    public HealthBar health;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectil"))
        {
            currentHealth -= damageReceived;
            health.SetHealth(currentHealth);
        }
    }
}