using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playParticle : MonoBehaviour
{
    [SerializeField] ParticleSystem particulas = null;
    public AudioSource explosionParticulas = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 

    {
        if (other.gameObject.CompareTag("projectil"))
        {
        particulas.Play();
        explosionParticulas.Play();
        }
    }
}
