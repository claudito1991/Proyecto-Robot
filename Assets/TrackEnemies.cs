using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;
    private float distanciaAenemigo;
    public float distanciaMusica = 100f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemigo");
        Debug.Log($"la cantidad de enemigos es {enemies.Length}");
        foreach (GameObject enemy in enemies)
        {
            distanciaAenemigo = Vector3.Magnitude(enemy.transform.position - player.transform.position);
            Debug.Log($"La distancia menor actual es {distanciaAenemigo}");
            if (distanciaAenemigo < distanciaMusica)
            {
                Debug.Log("Se reproduce la musica de combate");
            }
            else
            {
                Debug.Log("Se reproduce la musica tranqui");
            }
        }
    }
}
