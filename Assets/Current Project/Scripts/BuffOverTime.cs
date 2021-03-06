using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffOverTime : MonoBehaviour
{
    public pointsManager puntos;
    public float segundosDeVida = 10;

    public float puntosPorSegundo = 10;
    public Transform parentTower;
    // Start is called before the first frame update
    void Start()
    {
        puntos = GameObject.Find("GameManager").GetComponent<pointsManager>();
        parentTower = GetComponentInParent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator VidaDelBuff()
    {
        yield return new WaitForSeconds(segundosDeVida);
        puntos.buffSeActivo = false;
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            puntos.totalPoints += puntosPorSegundo * Time.deltaTime;

            // Cambio este valor para poder acceder a la camara de la torre
            puntos.buffSeActivo = true;
            //Esta linea le avisa al gameManager que objeto lo está llamando.
            puntos.objectCalling = parentTower.transform.root;
             StartCoroutine(VidaDelBuff());
        }

        
    }
}
