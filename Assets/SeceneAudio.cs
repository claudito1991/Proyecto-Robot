using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeceneAudio : MonoBehaviour
{
    public AudioSource BGM;

    // Start is called before the first frame update


    public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip == music)
        {
            return;
        }
        else
        {
            BGM.Stop();
            BGM.clip = music;
            Debug.Log($"bgm CLIP IS {BGM.clip.name}");
            BGM.Play();
        }
   
    }

}
