using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollisionAmmo : MonoBehaviour
{
    public GameObject vfxExplosion;
    public AudioSource localAudio;
    public AudioClip hitSfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {

            localAudio.PlayOneShot(hitSfx);
            Instantiate(vfxExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
       
        
    }

    
}
