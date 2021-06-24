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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!changeFace)
        {
            faceRenderer.sprite = happyFace;
        }

        else
        {
            faceRenderer.sprite = angryFace;
        }
    }
}
