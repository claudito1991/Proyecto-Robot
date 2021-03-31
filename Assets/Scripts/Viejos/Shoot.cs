using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    static Animator anim;
    public ParticleSystem muzzleFlash;
    public GameObject proyectile;
    public GameObject firePoint;
    public float disparoDelay = 0.0f;
    public AudioSource clip;
   
    // Start is called before the first frame update
    void Start()
    {
         // anim = GetComponent<Animator>();
     
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire"))
        {

            //es la forma de invocar al ienumerator para generar un delay
            StartCoroutine(delay());
           
            
            
        }
    }

    private void LaunchProjectile()
    {
       // Acá genero una instanciación que será mi disparo. Notar que la posición y la rotación la toma de un objeto que cree para que sea más fácil acceder a esas coordenadas.
        var instantiatedProjectile = Instantiate(proyectile, firePoint.transform.position, firePoint.transform.rotation);
    }

    private IEnumerator delay()
    {
        //creo este método porque es la única forma de llamar a waitForSeconds para crear un delay
        yield return new WaitForSeconds(disparoDelay);
        //anim.SetTrigger("isShoot");
        muzzleFlash.Play();
        LaunchProjectile();
        clip.Play();
    }
}
