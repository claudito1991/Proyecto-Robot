using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Billboard : MonoBehaviour
{
    public Camera cam;
    private Transform cameraPos;
    //Start is called before the first frame update

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        cameraPos = cam.transform;
        transform.LookAt(cameraPos.position + cameraPos.forward);
    }
}
