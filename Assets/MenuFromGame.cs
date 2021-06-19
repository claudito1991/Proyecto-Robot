using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFromGame : MonoBehaviour
{
    public void GoToMenu()

    {
        SceneManager.LoadScene(0);
    }

    public void CancelAction()
    {
        gameObject.SetActive(false);
    }
}
