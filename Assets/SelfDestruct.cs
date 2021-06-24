using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public GameObject particulas;
    private AudioSource audioParticulas;
    public MeshRenderer mesh;

    private void Start()
    {
        particulas.SetActive(false);

        audioParticulas = particulas.GetComponent<AudioSource>();
        audioParticulas.enabled = false;
        mesh.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            particulas.SetActive(true);
            audioParticulas.enabled = true;
            mesh.enabled = false;
            StartCoroutine(WaitForDestruction());
            other.GetComponent<Damage>().SubirVida();
        }
    }


    IEnumerator WaitForDestruction()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}


