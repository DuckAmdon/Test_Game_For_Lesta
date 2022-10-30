using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
