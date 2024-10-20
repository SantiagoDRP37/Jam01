using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
  public int gameStartScene;

  public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }
}
