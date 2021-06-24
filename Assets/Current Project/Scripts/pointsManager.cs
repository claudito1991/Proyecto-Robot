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
    public Transform objectCalling;
    public bool buffSeActivo;
    public TowerAnimation torreActiva;
    public TowerAnimation[]torres;
    private bool canWin = false;

    private List<TowerAnimation> torresActivas = new List<TowerAnimation>();
    public List<TowerAnimation> GetColliders() { return torresActivas; }


    private void Start() 
    {
        torres = FindObjectsOfType<TowerAnimation>();
        totalPoints = puntosInicio;
        barra.SetMaxReciclado(puntosMax);
        //Cursor.visible = false;
        buffSeActivo = false;
        objectCalling = null;
        

    }

    private void Update() 
    {
        WinningCondition();
       
       
        barra.SetReciclado(totalPoints);
        //Debug.Log("Los puntos de pointManager son " + totalPoints);
        PuntosCuandoNoHayEnemigos();
        //Debug.Log($"Estado del buff {buffSeActivo}");
        GettingCameras();
        if (torre  != null)
        {
            ChangeCameraPriority();
            ActivatingTower();
        }


        //Aqui voy a llamar al script de la torre que estoy activando
        

    }

    //En este método llamo al debug del totalizador de puntos.
    void Puntos()
    {
        Debug.Log(totalPoints);
    }

    public void PuntosCuandoNoHayEnemigos()
    {
        //if(GameObject.FindGameObjectsWithTag("enemigo").Length == 0)
        //{
        //    //Debug.Log("Hay " + GameObject.FindGameObjectsWithTag("enemigo").Length + " enemigos!!!" );

        //    //El código de abajo queda deshabilitado porque sino cuando no hay enemigos la barra sube de golpe y se gana el juego
        //    //totalPoints += puntosOverTime * Time.deltaTime;
        //}

        if (canWin)
        {
            totalPoints += puntosOverTime * Time.deltaTime;
        }
    }

    public void GettingCameras()
    {
        if (objectCalling)
        {
            torre = objectCalling.GetComponentInChildren<CinemachineVirtualCamera>();
        }
        else
        {
            objectCalling = null;
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

    public void ActivatingTower()
    {
        if (buffSeActivo)
        {
            torreActiva = objectCalling.GetComponent<TowerAnimation>();
            torreActiva.estaTorreActiva = true;
        }

        else
        {
            torreActiva = null;
        }
    }

    public void WinningCondition()
    {
        foreach (TowerAnimation torre in torres)
        {
            if (!torresActivas.Contains(torre) && torre.estaTorreActiva)
            {
                torresActivas.Add(torre);
            }
        }

        Debug.Log($"Las torres activas son {torresActivas.Count}");

        if (torresActivas.Count == torres.Length)
        {
            canWin = true;
        }

     


    }
}
