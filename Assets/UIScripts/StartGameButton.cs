using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int gameStartScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
}
