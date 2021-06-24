using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    private Transform selftransform;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        selftransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        selftransform.Rotate(Vector3.up, 360 * Time.deltaTime * rotationSpeed);
    }
}
