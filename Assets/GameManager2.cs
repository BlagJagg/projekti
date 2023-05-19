using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;

    public void LoseGame()
    {
        // Handle losing the game, e.g., stop the game or show a game-over screen
        Time.timeScale = 0f;
        Debug.Log("You lost!");
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }
}

