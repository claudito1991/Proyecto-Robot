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
    public bool buffSeActivo;
    private bool canWin = false;


    public recicladoBarra barra;
    public CinemachineVirtualCamera torreCam;
    public CinemachineVirtualCameraBase player;
    public Transform objectCalling;
    public TowerAnimation torreActiva;
    public TowerAnimation[] torres;
    public CinemachineVirtualCamera winningTowerCam;

 

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
        if (torreCam  != null)
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
            Debug.Log($"La camara que está llamando es {objectCalling.name}");
            torreCam = objectCalling.GetComponentInChildren<CinemachineVirtualCamera>();
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
            torreCam.Priority = 1;
            player.Priority = 0;
        }
        else
        {
            torreCam.Priority = 0;
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
        foreach (TowerAnimation tor in torres)
        {
            if (!torresActivas.Contains(tor) && tor.estaTorreActiva)
            {
                torresActivas.Add(tor);
            }
        }

        Debug.Log($"Las torres activas son {torresActivas.Count}");

        if (torresActivas.Count == torres.Length)
        {
            canWin = true;
            winningTowerCam.Priority = 1;
            player.Priority = 0;
        }

     


    }
}
