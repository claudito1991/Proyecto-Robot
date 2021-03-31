using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateOnEnter : MonoBehaviour
{
    public GameObject zonaGeneradora;
    

private void Start()
 {
    zonaGeneradora.SetActive(false);
 }
    // Start is called before the first frame update
private void OnTriggerEnter(Collider other) 
{
    if (other.gameObject.CompareTag("Player"))
    {
        zonaGeneradora.SetActive(true);
        zonaGeneradora.GetComponent<generateEnemies>().CrearEnemigos();
    }
    
}
    // Update is called once per frame

}
