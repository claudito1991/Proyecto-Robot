using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
   // public Transform target;
    public Transform enemyRadar;
    private EnemyRadar script;
    public Transform target;
    private Transform enemyLocked;
    private bool isEnemyLocked;
    public float distaceLocked = 15f;
    public Transform firePoint;
    private float maxDistance;
    private Vector3 lockedEnemyPosition;
    public Vector3 aimingOffset = new Vector3(0f, 2f, 0f);
    public float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //target = GetComponentInChildren<Transform>();
        script = enemyRadar.GetComponent<EnemyRadar>();
        lockedEnemyPosition = new Vector3(0f, 0f, 0f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Enemigo mas cercano {script.trans.name}");

       if (Input.GetKeyDown(KeyCode.Tab) && !isEnemyLocked)
        {
            isEnemyLocked = true;
            enemyLocked = script.trans;
            lockedEnemyPosition = enemyLocked.transform.position;
            Debug.Log($"the locked enemy is: {enemyLocked}");
            
        }

        
        target.position = enemyLocked.transform.position;
        



        maxDistance = Vector3.Distance(transform.position, enemyLocked.transform.position);

       if(enemyLocked == null || maxDistance > distaceLocked || Input.GetKeyDown(KeyCode.Tab))
        {
            isEnemyLocked = false;
        }


       
    }

    
}
