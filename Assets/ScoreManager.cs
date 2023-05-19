using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Transform player;        // Reference to the player's transform
    private float highestYPosition;  // The highest Y position achieved by the player
    private int score;               // The current score

    void Start()
    {
        // Find the player object using the "Player" tag and store its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Initialize the highestYPosition to the player's initial Y position
        highestYPosition = player.position.y;

        // Initialize the score to zero
        score = 0;
    }

    void Update()
    {
        // Get the current Y position of the player
        float currentYPosition = player.position.y;

        // If the current position is higher than the previous highest position
        if (currentYPosition > highestYPosition)
        {
            // Update the highestYPosition to the current position
            highestYPosition = currentYPosition;

            // Round the highestYPosition to an integer value and set it as the score
            score = Mathf.RoundToInt(highestYPosition);
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

        // Display the score label on the screen using the GUI.Label function
        // The label will be positioned at (10, 10) with a size of (100, 30)
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + score, style);
    }
}
