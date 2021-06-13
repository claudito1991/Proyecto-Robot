using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollisionAmmo : MonoBehaviour
{
    public ParticleSystem particulas = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            particulas.Play();
            Destroy(gameObject);
        }
        
    }

    
}
