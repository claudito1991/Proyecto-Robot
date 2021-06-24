using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioStart : MonoBehaviour
{

    public AudioSource sonido;
    private float randomStartingPoint;
    public float audioClipLength;
    // Start is called before the first frame update
    void Start()
    {
        audioClipLength = sonido.clip.length;
        randomStartingPoint = Random.Range(0.0f, audioClipLength);
        PlaySound();
    }

public void PlaySound()
        {
        sonido.time = randomStartingPoint;
        sonido.Play();
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
