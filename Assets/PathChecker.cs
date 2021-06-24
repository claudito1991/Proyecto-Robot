using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathChecker : MonoBehaviour
{
    public bool PathIsBlocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("barrier"))
        {
            //Debug.Log("Is colliding");
            PathIsBlocked = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("barrier"))
        {
            PathIsBlocked = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.CompareTag("barrier"))
        //{
        //    Debug.Log("Is not colliding");
        //    PathIsBlocked = false;
        //}
    }


}
