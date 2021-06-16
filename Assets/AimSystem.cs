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
    public Transform characterTransform;
 
    
    // Start is called before the first frame update
    void Start()
    {
        //target = GetComponentInChildren<Transform>();
        script = enemyRadar.GetComponent<EnemyRadar>();
        lockedEnemyPosition = new Vector3(0f, 0f, 0f);
        enemyLocked.position = new Vector3(15f,0,0) + firePoint.position;
        
        
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
            maxDistance = Vector3.Distance(transform.position, enemyLocked.transform.position);
        }


        //target.position = enemyLocked.transform.position;
        //transform.LookAt(enemyLocked.position);
        //TargetAiming();
        //AimingAngle();
            Aiming();

            
            
            
         
           
           
       
         
       
        

        if (enemyLocked == null || maxDistance > distaceLocked || Input.GetKeyDown(KeyCode.Tab))
        {
            isEnemyLocked = false;
        }


       
    }

    private void TargetAiming()
    {
        Vector3 targetDir = enemyLocked.position - transform.position;
        //targetDir.y = 0;
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);


    }

    private float AimingAngle()
    {
        Vector3 targetDir = enemyLocked.position - transform.position;
        float angle = Vector3.Angle(targetDir, characterTransform.forward);
        Debug.Log($"The angle between Canon and character is: {angle}");
        return angle;
    }

    private void Aiming()
    {
        
        if (AimingAngle() < 50)
        {
            TargetAiming();
        }
        else
        {
            

            isEnemyLocked = false;
        }
    }

    
}
