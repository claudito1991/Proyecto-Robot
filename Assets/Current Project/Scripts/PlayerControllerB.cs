using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerB : MonoBehaviour
{
    static Animator anim;
    public float velocidadCaminar = 10.0f;
    public float velocidadRotacion = 100.0f;
    public AudioSource sonidoPersonaje;
   
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
        sonidoPersonaje = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {


        float traslacion = Input.GetAxis("Vertical") * velocidadCaminar;
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotacion;

        transform.Translate(0, 0, traslacion * Time.deltaTime);
        transform.Rotate(0, rotacion * Time.deltaTime, 0);


        SonidoMovimiento(traslacion);
      

        if (traslacion != 0)
        {

            
            
            anim.SetBool("isWalk", true);
        }

        else
        {
            
            //Debug.Log($"se esta reproduciendo el audio: {sonidoPersonaje.isPlaying}");
            anim.SetBool("isWalk", false);

        }

        if (Input.GetButtonDown("Run"))
        {
            anim.SetTrigger("isRun");
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

    public void SonidoMovimiento (float traslacion)
    {
        if (!sonidoPersonaje.isPlaying && traslacion != 0)
        {
            
            sonidoPersonaje.volume = 0.2f;
            sonidoPersonaje.Play();
        }
    }
}
