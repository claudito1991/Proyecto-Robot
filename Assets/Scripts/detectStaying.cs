using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectStaying : MonoBehaviour
{
    public recicladoBarra barraReciclado;
    private int frame = 0;

    public static float sumado;
    // Start is called before the first frame update
private void OnTriggerEnter(Collider other) 
{

       if(other.gameObject.CompareTag("Player"))
    {
        //Debug.Log("Entraste en un objeto");
        frame = 0;
    }
    
}

private void OnTriggerExit(Collider other) 
{
        if(other.gameObject.CompareTag("Player"))
    {
       // Debug.Log("Saliste de un objeto");
        frame = 0;
    } 
}

 


public void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("Player") && frame < 102)
        
         {
             frame++;
             //Debug.Log("frames" + frame ) ;

         }

         if (frame>100 && frame < 102)
         {
             sumado = 200.0f;
             //Debug.Log("puntos sumados" +" "+  sumado);
            
         }


    }

private void Update() 
    {
        
    }


}
