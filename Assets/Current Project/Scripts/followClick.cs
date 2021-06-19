using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followClick : MonoBehaviour
 
{
    private Vector2 mousePos ;
    public Camera camara;
    private Vector3 screenPos ;
 
 void Update () {
     mousePos = Input.mousePosition;
     screenPos = camara.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - camara.transform.position.z));
     
     transform.rotation= Quaternion.Euler(Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x))*-Mathf.Rad2Deg,0,0);
 }
}
