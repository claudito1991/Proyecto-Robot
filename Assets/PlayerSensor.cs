using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public GameObject[] basuritas;
    public BoxCollider playerSensor;
    public bool estado ;
    // Start is called before the first frame update
    void Start()
    {

        estado = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        EnablingGarbage(estado);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estado = true;
        }
    }

    public void EnablingGarbage (bool estado)
    {
        if (estado)
        {
            foreach (GameObject basura in basuritas)
            {
                basura.SetActive(true);
              
            }
        }
    }
}
