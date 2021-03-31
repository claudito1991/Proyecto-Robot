using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsManager : MonoBehaviour
{
    public float totalPoints =   0.0f;

    public float puntosMax = 10000;
    public float puntosInicio = 5000;

    public float puntosOverTime = 50;

    public recicladoBarra barra;

    private void Start() 
    {

        totalPoints = puntosInicio;
        barra.SetMaxReciclado(puntosMax);

    }

    private void Update() 
    {
        barra.SetReciclado(totalPoints);
        //Debug.Log("Los puntos de pointManager son " + totalPoints);
        PuntosCuandoNoHayEnemigos();
    }

    //En este método llamo al debug del totalizador de puntos.
    void Puntos()
    {
        Debug.Log(totalPoints);
    }

    public void PuntosCuandoNoHayEnemigos()
    {
        if(GameObject.FindGameObjectsWithTag("enemigo").Length == 0)
        {
            Debug.Log("Hay " + GameObject.FindGameObjectsWithTag("enemigo").Length + " enemigos!!!" );
            totalPoints += puntosOverTime * Time.deltaTime;
        }
    }
}
