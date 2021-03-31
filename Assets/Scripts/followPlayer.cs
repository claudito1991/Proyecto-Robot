using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //chequeo si el jugador existe. Si lo borré no voy a hacer nada
        if (!player == false)
        {
        transform.position = player.position + offset;
        }
    }
}
