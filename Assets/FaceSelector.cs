using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceSelector : MonoBehaviour
{
    public Sprite happyFace;
    public Sprite angryFace;
    public Image faceRenderer;
    public bool changeFace;
    private MusicSwitcher audioManager;
    private bool musicPlaying;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<MusicSwitcher>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        musicPlaying = audioManager.isBackgroundPlaying;
        if (musicPlaying)
        {
            faceRenderer.sprite = happyFace;
        }

        else
        {
            faceRenderer.sprite = angryFace;
        }
    }
}
