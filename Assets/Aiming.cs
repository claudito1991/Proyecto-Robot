using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour



{
    public Camera camera;
    private bool ray_hit_something = false;

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            ray_hit_something = true;
        }
        else
        {
            ray_hit_something = false;
        }

        if (ray_hit_something == true)
        {
            Debug.Log($"The hit point is: {hit.point}");
            transform.LookAt(Camera.main.ViewportToScreenPoint(hit.point));
        }

        Debug.DrawRay(transform.position, hit.point);
    }
}
