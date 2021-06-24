using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    public AudioClip battleClip;
    public AudioClip background;
    private SeceneAudio audioManager;
    
    private List<Collider> colliders = new List<Collider>();
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemigo"))
        {
            audioManager.ChangeBGM(battleClip);
            isBackgroundPlaying = false;
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
        //if (colliders.Count == 0)
        //{
        //    audioManager.ChangeBGM(background);
        //}

    

        Debug.Log($"Hay {colliders.Count} enemigos en rango");
    }

  

 
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("enemigo"))
        {
            colliders.Remove(other);
            Debug.Log("enemigo removido");
        }

        if (colliders.Count == 0)
        {
            audioManager.ChangeBGM(background);
            isBackgroundPlaying = true;
        }


    }

}


