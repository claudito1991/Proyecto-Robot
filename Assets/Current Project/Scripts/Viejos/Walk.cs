using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    static Animator anim;
    public float velocidadCaminar = 10.0f;
    public float velocidadRotacion = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
       
    }
}
