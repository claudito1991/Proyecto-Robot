using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnimation : MonoBehaviour
{
    public Animator towerAnimator;
    public bool estaTorreActiva;
    public Transform[] fans;
    public FanActivation fanActivator;
    // Start is called before the first frame update
    void Start()
    {
        estaTorreActiva = false;
        fanActivator.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Torre activa ? {estaTorreActiva}");
        if (estaTorreActiva)
        {
            towerAnimator.SetTrigger("isBuffActive");
            Debug.Log("Se dispara el trigger");
            fanActivator.enabled = true;
 
        }
        
    }


}
