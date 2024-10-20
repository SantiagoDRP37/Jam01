
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIController Instance;
    public Image[] hearts;
    public Sprite heartFull, heartEmpty;

    public int health;

    

    private void Awake() {

         Instance = this;   
    }

    
    void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = heartFull;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //actualiza el contador de vida
    [ContextMenu("UpdateHealth")] 
    public void UpdateHealthDisplay()
    {

        if (health >=0)
        {
            hearts[health].sprite = heartEmpty;
            health--;
        }
    }

}
