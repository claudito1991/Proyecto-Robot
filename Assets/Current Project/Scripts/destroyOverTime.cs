using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOverTime : MonoBehaviour
{
    public GameObject proyectile;
    public float tiempoDeVida = 3.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       Destroy(proyectile, tiempoDeVida);
    }



}
