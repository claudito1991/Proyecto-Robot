using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static Animator anim;
    public float velocidadCaminar = 10.0f;
    public float velocidadRotacion = 100.0f;
    public GameObject proyectile;
    public GameObject firePoint;

    private pointsManager puntos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        puntos = GameObject.Find("GameManager").GetComponent<pointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float traslacion = Input.GetAxis("Vertical") * velocidadCaminar;
        float rotacion = Input.GetAxis("Horizontal") * velocidadRotacion;

        transform.Translate(0, 0, traslacion * Time.deltaTime);
        transform.Rotate(0, rotacion * Time.deltaTime, 0);

        if (traslacion != 0)
        {
            anim.SetBool("isWalk", true);
        }

        else
        {
            anim.SetBool("isWalk", false);

        }

                if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJump");
        }

                if (Input.GetButtonDown("Fire"))
        {
           var instantiatedProyectile = Instantiate(proyectile, firePoint.transform.position, firePoint.transform.rotation );
           Debug.Log("Disparo");
        }

        GameOver();
    }

    public void GameOver()
    {
        if(puntos.totalPoints < 0.1f || puntos.totalPoints > 9999.0f)
        {
            Destroy(gameObject);
        }
    }
}
