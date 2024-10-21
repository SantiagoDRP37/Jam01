using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{

  public static MenuManagerScript Instance;
  public int gameStartScene;
  public int backStartScene;

   private void Awake() {

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
  public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
    }

  public void BackToStarMenu()
    {
      SceneManager.LoadScene(gameStartScene);
    }
}
