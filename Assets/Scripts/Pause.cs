using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject botonpausa;

    [SerializeField] private GameObject MenuPausa;

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
}
