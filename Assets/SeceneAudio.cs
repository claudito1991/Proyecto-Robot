using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeceneAudio : MonoBehaviour
{
    public AudioSource sceneAudio;
    public AudioClip backgroundAudio;
    public AudioClip battleAudio;
    public SphereCollider detectionRange;
    public Transform player;
    public bool enemyOnRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (enemyOnRange == false)
        {
            Debug.Log("Background audio Playing");
            sceneAudio.clip = backgroundAudio;
            sceneAudio.Play();
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            Debug.Log("Battle audio Playing");
            enemyOnRange = true;
            if (!sceneAudio.isPlaying)
            {
                
                sceneAudio.clip = battleAudio;
                sceneAudio.Play();
            }
          

        }
        else
        {
            enemyOnRange = false;
        }
    }

}
