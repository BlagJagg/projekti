using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Transform player;         // Reference to the player's transform
    private float currentYPosition;   // The current Y position of the player
    private int highScore;            // The saved high score

    void Start()
    {
        // Find the player object using the "Player" tag and store its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Initialize the currentYPosition to the player's initial Y position
        currentYPosition = player.position.y;

        // Load the saved high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        // Get the current Y position of the player
        float newCurrentYPosition = player.position.y;

        // If the new position is lower than the current position, update the current position
        if (newCurrentYPosition < currentYPosition)
        {
            currentYPosition = newCurrentYPosition;
        }
    }

    void OnGUI()
    {
        // Create a GUIStyle object
        GUIStyle style = new GUIStyle();

        // Set the font size of the style to 24
        style.fontSize = 24;

        // Set the text color of the style to black
        style.normal.textColor = Color.black;

        // Display the current score label on the screen using the GUI.Label function
        // The label will be positioned at (10, 10) with a size of (200, 30)
        GUI.Label(new Rect(10, 10, 200, 30), "Score: " + Mathf.RoundToInt(currentYPosition), style);

        // Display the high score label on the screen using the GUI.Label function
        // The label will be positioned below the current score label with a size of (200, 30)
        GUI.Label(new Rect(10, 40, 200, 30), "High Score: " + highScore, style);
    }

    void OnDestroy()
    {
        // Check if the current score is higher than the saved high score
        int currentScore = Mathf.RoundToInt(currentYPosition);
        if (currentScore > highScore)
        {
            // Update the high score
            highScore = currentScore;

            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
}
