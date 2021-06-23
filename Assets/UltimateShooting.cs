using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateShooting : MonoBehaviour
{
    public GameObject proyectile;
    public Transform firePoint;
    public GameObject vfxShooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      
        

        if (Input.GetButtonDown("Fire"))
        {
            

            var instantiatedProyectile = Instantiate(proyectile, firePoint.transform.position, firePoint.transform.rotation);
            Instantiate(vfxShooting, firePoint.transform.position, firePoint.transform.rotation);



        }
    }



}
