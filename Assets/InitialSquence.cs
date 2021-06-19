using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;
public class InitialSquence : MonoBehaviour
{
    public GameObject player;
    public GameObject initialDialogue;
    public CinemachineBrain mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        

    }

    private void OnEnable()
    {
        initialDialogue.SetActive(true);
        player.GetComponent<PlayerControllerB>().enabled = false;
        mainCamera.enabled = false;
        player.GetComponent<UltimateShooting>().enabled = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        if(!initialDialogue.activeSelf)
        {
            player.GetComponent<PlayerControllerB>().enabled = true;
            mainCamera.enabled = true;
            player.GetComponent<UltimateShooting>().enabled = true;
        }
    }


    void GoToMenu ()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
