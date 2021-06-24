using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    CapsuleCollider playerCollider;
    public int MaxHealth = 100;
    public int currentHealth;
    public int damage = 10;
    public int recover = 25;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemyprojectile"))
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Debug.Log("Colision projectil enemigo");
        }


    }

    public void SubirVida()
    {
        currentHealth += recover;
        healthBar.SetHealth(currentHealth);
    }

   
}
