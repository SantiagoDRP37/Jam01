using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Transform player;  // Referencia al Transform del jugador
    public Vector3 offset;     // Offset de la luna respecto al jugador

    // Start is called before the first frame update
    void Start()
    {
        // Busca al jugador por el nombre del GameObject
        GameObject playerObject = GameObject.Find("Hero");  // Asegúrate de que "Hero" sea el nombre de tu jugador
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)  // Asegurarse de que el jugador no sea nulo
        {
            // Igualar la posición en X del jugador
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + 0.3f, transform.position.z);
        }
    }
}
