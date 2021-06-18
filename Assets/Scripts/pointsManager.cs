using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class pointsManager : MonoBehaviour
{
    public float totalPoints =   0.0f;

    public float puntosMax = 10000;
    public float puntosInicio = 5000;
    public float puntosOverTime = 50;
    public recicladoBarra barra;
    public CinemachineVirtualCamera torre;
    public CinemachineVirtualCameraBase player;

    public bool buffSeActivo;

    private void Start() 
    {

        totalPoints = puntosInicio;
        barra.SetMaxReciclado(puntosMax);
        //Cursor.visible = false;
        buffSeActivo = false;

    }

    private void Update() 
    {
        barra.SetReciclado(totalPoints);
        //Debug.Log("Los puntos de pointManager son " + totalPoints);
        PuntosCuandoNoHayEnemigos();
        Debug.Log($"Estado del buff {buffSeActivo}");
        ChangeCameraPriority();

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
            //Debug.Log("Hay " + GameObject.FindGameObjectsWithTag("enemigo").Length + " enemigos!!!" );

            //El código de abajo queda deshabilitado porque sino cuando no hay enemigos la barra sube de golpe y se gana el juego
            //totalPoints += puntosOverTime * Time.deltaTime;
        }
    }

    public void ChangeCameraPriority()
    {
        if (buffSeActivo)
        {
            torre.Priority = 1;
            player.Priority = 0;
        }
        else
        {
            torre.Priority = 0;
            player.Priority = 1;
        }
    }
}
