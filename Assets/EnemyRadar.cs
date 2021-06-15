using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour
{
    private GameObject[] multipleEnemys;
    public Transform closestEnemy;
    private bool enemyContact;
    public Transform trans=null;
    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
        enemyContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.isTrigger != true && other.gameObject.CompareTag("enemigo"))
        {
            closestEnemy = getClosestEnemy();
           // closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
           // Debug.Log($"the closest enemy is {closestEnemy.gameObject.name}");
            enemyContact = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger != true && other.gameObject.CompareTag("enemigo"))
        {
            enemyContact = false;
           // closestEnemy.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        
    }

    public Transform getClosestEnemy()
    {
        multipleEnemys = GameObject.FindGameObjectsWithTag("enemigo");
        //Debug.Log($"There are {multipleEnemys.Length} enemigos");
        float closestDistance = Mathf.Infinity;
        //Transform trans = null;

        foreach(GameObject go in multipleEnemys)
        {
            float currentDistance;
            //currentDistance = Vector3.Distance(transform.position, go.transform.position);
            currentDistance = (go.transform.position - transform.position).sqrMagnitude;
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
            
        }
        return trans;
    }
}
