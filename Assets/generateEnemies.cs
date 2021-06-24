using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateEnemies : MonoBehaviour
{
    public Collider zona;
    public Vector3 posicion;

    public Bounds limite;

    public GameObject Enemigo;

    private int contador;
    public int  maxEnemies;

    
    private void Start() 
    {
        
    }
    
    // Start is called before the first frame update
    public void CrearEnemigos() 
    {
       
       StartCoroutine(EnemyDrop());

    }

    // Update is called once per frame
    void Update()
    {
      //Debug.Log("La posicion es"+" "+posicion);  
    }
        IEnumerator EnemyDrop()
    {
        while (contador < maxEnemies)
        {
         limite= zona.bounds; 
        posicion = new Vector3(
           Random.Range(limite.min.x , limite.max.x),
           Random.Range(limite.min.y, limite.max.y),
           Random.Range(limite.min.z, limite.max.z)
       );

        Instantiate(Enemigo, posicion, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        //Debug.Log("Se creo un enemigo");
        contador +=1;
        


        
    }

}
}
