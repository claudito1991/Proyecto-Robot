using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float movementSpeed = 5f;

    static Animator anim;

    private float attackRange = 20f;
    private float rayDistance = 10.0f;
    private float stoppingDistance = 3f;
    private float chasingStoppingDistance = 10f;
    
    private float detectionRadius = 40f;
    private float distanceToPlayer;
    private float targetOffset = 2f;


    private Vector3 destination;
    private Quaternion desiredRotation;
    private Vector3 direction;
    private GameObject player;
    private Transform target;
    private EnemyState currentState;
    private Vector3 playerDirection;
    public GameObject vfxShooting;

    



    public enum EnemyState
    {
        Wander,
        Chase,
        Attack
    }
    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case EnemyState.Wander:
                {
                   
                    if (NeedDestination())
                    {
                        GetDestination(); // esto calcula un vector direction y una rotación para llegar a mirar en esa dirección

                    }

                    transform.rotation = desiredRotation; //acá se tendría que suavizar la rotación

                    transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

                    var rayColor =  IsPathBlocked() ? Color.red : Color.green;
                    
                    Debug.DrawRay(transform.position, direction * rayDistance, rayColor);

                    while (IsPathBlocked())
                    {
                        Debug.Log("Path is blocked");
                        GetDestination();
                    }

                    if (PlayerInSight())
                    {
                        //playerDirection = Vector3.Normalize(target.position - transform.position);
                        //playerDirection = new Vector3(playerDirection.x, 1f, playerDirection.z);
                        //desiredRotation = Quaternion.LookRotation(direction);
                        currentState = EnemyState.Chase;
                        
                       
                    }

                    
                    break;

                }
            case EnemyState.Chase:
                {
                    //Debug.Log("Te persigo");
                    if (!PlayerInSight())
                    {
                        currentState = EnemyState.Wander;
                        anim.SetBool("isWalk", true);

                        return;
                    }

                    var targetLocation = new Vector3(target.position.x, target.position.y + targetOffset, target.position.z);
                    transform.LookAt(targetLocation);

                    if (Vector3.Distance(targetLocation,transform.position) > chasingStoppingDistance)
                    { 
                        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * 1.3f);
                    }
                    

                    if (Vector3.Distance(transform.position, target.position) < attackRange)
                    {
                        
                        currentState = EnemyState.Attack;
                    }
                    break;
                }
            case EnemyState.Attack:
                {

                    //if (PlayerInSight())
                    //{
                        var targetLocation = new Vector3(target.position.x, target.position.y + targetOffset, target.position.z);
                        transform.LookAt(targetLocation);
                        anim.SetBool("isWalk", false);
                        anim.SetTrigger("isAttack");
                        //Debug.Log("Te ataco");
                        EnemyShooting();
                    //}
                    if (PlayerInSight())
                    {
                        currentState = EnemyState.Chase;
                        anim.SetBool("isWalk", true);
                    }

                    if (!PlayerInSight())
                    {
                        currentState = EnemyState.Wander;
                    }

                    break;
                
                }
        }
    }

    private bool NeedDestination()
    {
        if(destination == Vector3.zero)
        {
            return true;
        }

        var distance = Vector3.Distance(transform.position, destination);
        if (distance <= stoppingDistance)
        {
            return true;
        }

        return false;
    }


    private void GetDestination()
    {
        Vector3 testPosition = (transform.position + (transform.forward * 1.0f)) + new Vector3(Random.Range(-4.5f, 4.5f), 0f, Random.Range(-4.5f, 4.5f));

        destination = new Vector3(testPosition.x, 1f, testPosition.z);

        direction = Vector3.Normalize(destination - transform.position);
        direction = new Vector3(direction.x, 0f, direction.z);

        desiredRotation = Quaternion.LookRotation(direction);
    }

    private bool IsPathBlocked()
    {
        Ray ray = new Ray(transform.position, direction);
        var hitSomething = Physics.RaycastAll(ray, rayDistance, layerMask);
       
        if (hitSomething.Length > 0)
        {
            return true;
        }

        return false;
    }

    private bool PlayerInSight()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);
        //Debug.Log($"distance to player is {distanceToPlayer}");
        if (distanceToPlayer < detectionRadius)
        {
            return true;
        }

        return false;
    }

    public GameObject proyectile;
    public GameObject firePoint;

    
    private float Cooldown = 0.5f;
    private float lastShoot = 2f;
    // Start is called before the first frame update
    private void EnemyShooting()
    {
        
        lastShoot += Time.deltaTime;

        //Debug.Log($"last shoot was {lastShoot}");
        if (Cooldown < lastShoot)
        {
            lastShoot = 0;
            var instantiatedProyectile = Instantiate(proyectile, firePoint.transform.position, firePoint.transform.rotation);
            Instantiate(vfxShooting, firePoint.transform.position, firePoint.transform.rotation);
            
        }

       
    }
}
