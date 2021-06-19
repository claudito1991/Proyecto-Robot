using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] ParticleSystem particulas = null;
    public AudioSource explosionParticulas;

    public AudioClip explosion;
    public float puntosAlMorir=50f;
    public float puntosOverTime=1.0f;

    public GameObject enemigo;

   

    private pointsManager puntos;

    private CapsuleCollider colisionador;
    // Start is called before the first frame update
    void Start()
    {
        explosionParticulas = GetComponent<AudioSource>();
       
        puntos = GameObject.Find("GameManager").GetComponent<pointsManager>();
        colisionador = GetComponent<CapsuleCollider>();        
    }

        private void OnTriggerEnter(Collider other)
    {
        // Si lo que colisionó fue un proyectil, se destruye la malla del objeto, se escucha la explisión y se reproducen las partículas
         if (other.gameObject.CompareTag("projectil"))
        {
            colisionador.enabled = false;
            explosionParticulas.PlayOneShot(explosion);
            particulas.Play();
            //gameManager.totalScore += 50.0f;
            Destroy(enemigo);
            
        }
    
        
          

    }

    // Update is called once per frame
    void Update()
    {
        puntos.totalPoints-= puntosOverTime * Time.deltaTime;
        //Si el empty no tiene malla y no tiene partículas, se destruye luego de un determinado tiempo (ahorro de memoria)
          if( transform.Find("explosion") == null && transform.Find("enemigo_malla") == null  )
       {
           StartCoroutine(WaitToDie());
           
       }
        
    }



        public void OnDestroy() 
    {
        //al destruirse el objeto se suman puntos al pointsManager
        puntos.totalPoints += puntosAlMorir;
        //Debug.Log("Se agregaron" + puntosAlMorir);
        
    }
    
        private IEnumerator WaitToDie()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }
    
}
