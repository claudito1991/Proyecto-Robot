using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionStarter : MonoBehaviour
{

    public GameObject pollution;
    private ParticleStopper[] particles;
    private ParticleSystem[] particulas;
    
    // Start is called before the first frame update

    private void Start()
    {
        particles =pollution.GetComponentsInChildren<ParticleStopper>();
        particulas = pollution.GetComponentsInChildren<ParticleSystem>();
    }

    public void PlayPollution ()
    {
        if (particles != null)
        {
            foreach (ParticleStopper pol in particles)
            {
                pol.GetComponent<ParticleStopper>().enabled = true;
            }
        }

    }

    //public void PausePollution()
    //{
    //    foreach (ParticleStopper pol in particles)
    //    {
    //        pol.GetComponent<ParticleStopper>().enabled = false;
    //    }
    //}


}
