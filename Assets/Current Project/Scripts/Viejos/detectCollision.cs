using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
   
   public GameObject enemigo;

    
 
    // Start is called before the first frame update
    void Start()
    {
    

        
    }


      
    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
      {
        if (other.gameObject.CompareTag("projectil"))
        {
          Destroy(enemigo);
            
            
        }
      
      }  

    

}
