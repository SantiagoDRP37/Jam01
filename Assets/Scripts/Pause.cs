using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;



public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject botonpausa;

    [SerializeField] private GameObject MenuPausa;

    public GameObject Hero;

    public void pausa()
    {
        Time.timeScale = 0f;
        botonpausa.SetActive(false);
        MenuPausa.SetActive(true);
    }

    public void reanudar()
    {
        Time.timeScale = 1.0f;
        botonpausa.SetActive(true);
        MenuPausa.SetActive(false);
    }

    public void restart()
    {
        if (Hero.transform.position.x <= 28.0f)
        {
            Hero.transform.position = new Vector3(-1.1f, -0.32f, 0);
            Time.timeScale = 1.0f;
            botonpausa.SetActive(true);
            MenuPausa.SetActive(false);
        }
        else
        {
            Hero.transform.position = new Vector3(33.0f, 0.64f, 0);
            Time.timeScale = 1.0f;
            botonpausa.SetActive(true);
            MenuPausa.SetActive(false);
        }
    }

}

