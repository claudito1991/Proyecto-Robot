using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnimation : MonoBehaviour
{
    public Animator towerAnimator;
    public bool estaTorreActiva;
    public Transform[] fans;
    public FanActivation fanActivator;
    public PollutionStarter pollutionParticles;
    public int secondsPollution;
    public AudioSource sonidoInicial;
    public AudioSource sonidoContinue;
    public AudioClip audioClipInicio;

    public float inicialVolume = 0.8f;
    public float continueVolume = 0.7f;
    // Start is called before the first frame update

    private void Awake()
    {   

    }
    void Start()
    {
        estaTorreActiva = false;
        fanActivator.enabled = false;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Torre activa ? {estaTorreActiva}");
        if (estaTorreActiva)
        {
            towerAnimator.SetTrigger("isBuffActive");
            //Debug.Log("Se dispara el trigger");
            fanActivator.enabled = true;
            pollutionParticles.PlayPollution();
            sonidoInicial.volume = inicialVolume;
            sonidoInicial.PlayOneShot(audioClipInicio);
            if(!sonidoInicial.isPlaying)
            {
                sonidoContinue.volume = continueVolume;
                sonidoContinue.Play();
            }

 
        }
        
    }


  


}
