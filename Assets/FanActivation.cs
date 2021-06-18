using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanActivation : MonoBehaviour
{
    private bool isActive;
    public Transform fan1;
    public Transform fan2;
    public Transform fan3;
    public Transform fan4;
    
   
    public float targetSpeed = 500;
    public float currentSpeed = 0;
    public float timeForMaxSpeed = 10f;
   

    // Start is called before the first frame update
    void Start()
    {
       

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isActive)
        {
            StartFan(fan1,targetSpeed);
            StartFan(fan2, targetSpeed);
            StartFan(fan3, targetSpeed);
            StartFan(fan4, targetSpeed);
            //fan2.Rotate(Vector3.forward * fanSpeed * Time.deltaTime);
            //fan3.Rotate(Vector3.forward * fanSpeed * Time.deltaTime);
            //fan4.Rotate(Vector3.forward * fanSpeed * Time.deltaTime);

        }
    }

    private void OnEnable()
    {
        isActive = true;

    }


    

    public void StartFan(Transform fan, float targetSpeed)
    {

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * timeForMaxSpeed);
        fan.Rotate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
