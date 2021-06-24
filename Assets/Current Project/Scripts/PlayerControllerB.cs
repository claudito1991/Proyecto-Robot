using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerB : MonoBehaviour
{
    static Animator anim;
    public float velocidadCaminar = 10.0f;
    public float velocidadRotacion = 100.0f;
    public float velocidadActual = 10f;
    public float velocidadCorrer = 40f;
    public AudioSource sonidoPersonajeCaminar;
    public AudioSource sonidoPersonajeCorrer;
 
   
    //public GameObject proyectile; queda comentado porque lo voy a implementar con IK bones
    //public GameObject firePoint;
    private pointsManager puntos;
    public Damage health;
    public findPersonaje estado;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        puntos = GameObject.Find("GameManager").GetComponent<pointsManager>();
       
        //sonidoPersonaje = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {


        float traslacion = Input.GetAxis("Vertical") * velocidadActual;
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotacion;

        transform.Translate(0, 0, traslacion * Time.deltaTime);
        transform.Rotate(0, rotacion * Time.deltaTime, 0);


        
      

        if (traslacion != 0 && Input.GetKey(KeyCode.LeftShift)== false)
        {
            velocidadActual = velocidadCaminar;
            anim.SetBool("isWalk", true);
            sonidoPersonajeCorrer.Stop();
            if(!sonidoPersonajeCaminar.isPlaying)
            {
                sonidoPersonajeCaminar.Play();
                Debug.Log("Se reproduce la caminata");
            }
            
            
           
        }

        else
        {
            
            //Debug.Log($"se esta reproduciendo el audio: {sonidoPersonaje.isPlaying}");
            anim.SetBool("isWalk", false);

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadActual = velocidadCorrer;
            anim.SetBool("isRun",true);
            anim.SetBool("isWalk", false);
            sonidoPersonajeCaminar.Stop();

            if (!sonidoPersonajeCorrer.isPlaying)
            {
                sonidoPersonajeCorrer.Play();
                Debug.Log("Se reproduce la corrida");
            }



        }



        else
        {
            anim.SetBool("isRun", false);
            
        }

        //if (Input.GetButtonDown("Fire"))
        //{
        //    var instantiatedProyectile = Instantiate(proyectile, firePoint.transform.position, firePoint.transform.rotation);
        //    Debug.Log("Disparo");
        //}

        GameOver();
    }

    
    public void GameOver()
    {
        if (puntos.totalPoints < 0.1f ||  health.currentHealth <= 0)
        {
            estado.DefeatMessage(true);
            Destroy(gameObject);
        }

        if (puntos.totalPoints > 9999.9f)
        {
            estado.DefeatMessage(false);
            Destroy(gameObject);
        }    
    }

    public void CambiarSonidoMovimiento (AudioClip musica)
    {


    }
}
