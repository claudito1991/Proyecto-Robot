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
    public GameObject menu;
    public Animator playerAnim;
    private GameObject[] enemigo;
    // Start is called before the first frame update
    void Awake()
    {
        enemigo = GameObject.FindGameObjectsWithTag("enemigo");

    }

    private void OnEnable()
    {
        initialDialogue.SetActive(true);
        //player.GetComponent<PlayerControllerB>().enabled = false;
        //playerAnim.GetComponent<Animator>().enabled= false;
        //mainCamera.enabled = false;
        //player.GetComponent<UltimateShooting>().enabled = false;
        //menu.SetActive(false);
        //EnemyInitial();
    

    }

    // Update is called once per frame
    void Update()
    {
        if(!initialDialogue.activeSelf)
        {
           // player.GetComponent<PlayerControllerB>().enabled = true;
           // playerAnim.GetComponent<Animator>().enabled = true;
           // mainCamera.enabled = true;
           // player.GetComponent<UltimateShooting>().enabled = true;
           //// EnemyInGame();

            
            if (Input.GetKeyDown(KeyCode.Escape))
           {

                menu.SetActive(true);
           }
        }
    }

    public void initialSquence ()
    {
        
        player.GetComponent<PlayerControllerB>().enabled = false;
        playerAnim.GetComponent<Animator>().enabled = false;
        mainCamera.enabled = false;
        player.GetComponent<UltimateShooting>().enabled = false;
        menu.SetActive(false);
        EnemyInitial();

      
    }

    public void InitialSequenceEnd()
    {
        player.GetComponent<PlayerControllerB>().enabled = true;
        playerAnim.GetComponent<Animator>().enabled = true;
        mainCamera.enabled = true;
        player.GetComponent<UltimateShooting>().enabled = true;
        EnemyInGame();

    }




    public void EnemyInGame()
    {
        foreach (GameObject enemy in enemigo)
        {
            if (enemy.activeSelf == false)
            {
                enemy.SetActive(true);
            }


        }
    }

    public void EnemyInitial()
    {
        foreach (GameObject enemy in enemigo)
        {
            if (enemy.activeSelf == true)
            {
                enemy.SetActive(false);
            }


        }

    }





}
