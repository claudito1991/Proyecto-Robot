using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioClip battleClip;
    public AudioClip background;
    private SeceneAudio audioManager;
    
    public List<Collider> colliders = new List<Collider>();
    public List<Collider> GetColliders() { return colliders; }

    public bool isBackgroundPlaying;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<SeceneAudio>();
        audioManager.ChangeBGM(background);
        isBackgroundPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log($"Los colliders son {colliders.Count}");
        if(colliders.Count  == 0)
        {
            //Debug.Log("Se deberia reproducir BG");
            audioManager.ChangeBGM(background);
            isBackgroundPlaying = true;
        }
        else
        {
            //Debug.Log("Se deberia reproducir combate");
            audioManager.ChangeBGM(battleClip);
            isBackgroundPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            //audioManager.ChangeBGM(battleClip);
            //
        }

        {
            if (!colliders.Contains(other) && other.CompareTag("enemigo"))
            { 
                colliders.Add(other);
            }
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("enemigo"))
        {
           // Debug.Log("hay enemigos aqui");
        }
        else
        {
            //Debug.Log("No hay enemigos aqui");
        }
        
    }

  

 
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("enemigo"))
        {
            colliders.Remove(other);
            //Debug.Log("enemigo removido");
        }

        if (colliders.Count == 0)
        {
            //audioManager.ChangeBGM(background);
            //isBackgroundPlaying = true;
        }


    }

}


