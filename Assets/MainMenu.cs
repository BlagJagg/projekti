using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("spawn");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnGUI()
    {
        // Create a GUIStyle object
        GUIStyle style = new GUIStyle();

        // Set the font size of the style to 24
        style.fontSize = 24;

        // Set the text color of the style to the specified color

        style.normal.textColor = Color.white;

        // Get the high score from PlayerPrefs
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Calculate the position for the high score label
        float labelWidth = 630f;
        float labelHeight = 400f;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float labelX = (screenWidth - labelWidth) / 1f;
        float labelY = (screenHeight - labelHeight) / 1f;

        // Display the high score label on the screen using the GUI.Label function
        // The label will be positioned in the middle of the screen
        GUI.Label(new Rect(labelX, labelY, labelWidth, labelHeight), "High Score: " + highScore, style);
    }
}
