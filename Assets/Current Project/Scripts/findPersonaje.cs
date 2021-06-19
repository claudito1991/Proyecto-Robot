using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findPersonaje : MonoBehaviour
{
    private int jugador;
    public Text derrota;
    public Text victoria;

    private pointsManager puntos;
    // Start is called before the first frame update
    void Start()
    {
        puntos = GameObject.Find("GameManager").GetComponent<pointsManager>();
        derrota.enabled = false;
        victoria.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       jugador = GameObject.FindGameObjectsWithTag("Player").Length;
       if (jugador < 1 && puntos.totalPoints < 2.0f)
        {
            derrota.enabled = true;
        }
        if (puntos.totalPoints > 9999.0f)
        {
            victoria.enabled = true;
        }
      
    }
}
