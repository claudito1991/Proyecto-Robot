using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDies : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageReceived = 10;

    public HealthBar health;
    public MusicSwitcher cambiadorMusica;
    public BoxCollider selfCollider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playerprojectile"))
        {
            currentHealth -= damageReceived;
            health.SetHealth(currentHealth);
        }
    }

    private void OnDestroy()
    {
        if (cambiadorMusica.colliders.Contains(selfCollider))
            {
            cambiadorMusica.colliders.Remove(selfCollider);
            }
    }
}
