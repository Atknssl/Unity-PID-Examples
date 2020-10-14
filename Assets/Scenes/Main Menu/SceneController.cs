using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadBalance()
    {
         SceneManager.LoadScene("Balance Rod");
    }

    public void LoadAltitude()
    {
         SceneManager.LoadScene("Altitude Control");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
