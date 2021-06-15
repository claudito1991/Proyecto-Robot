using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForEnemies : MonoBehaviour
{
    public float detectRadius = 20f;
    private GameObject closest;
    private float minDistance = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()


    {
        //encuentra todos los colliders dentro del radio de la esfera
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectRadius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            GameObject hitCollider = hitColliders[i].gameObject;
            // si el hitcollider tiene tag enemigo entra en el bloque
            if (hitCollider.CompareTag("enemigo"))
            {
               
                Debug.Log($"There are {hitColliders.Length} enemies");
                // tomo la distancia actual entre el personaje y el enemigo que estoy evaluando
                float distanciaActual = Vector3.Distance(hitCollider.transform.position, transform.position);

                Debug.Log($"current distance is: {distanciaActual}");

                if (distanciaActual < minDistance)
                {

                    minDistance = distanciaActual;
                    closest = hitCollider;
                    Debug.Log($" the closer one is: {closest.name}");
                }
                minDistance = 1000;
            }
           
        }
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
}
