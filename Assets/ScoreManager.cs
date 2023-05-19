using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Transform player;
    private float highestYPosition;
    private int score;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        highestYPosition = player.position.y;
        score = 0;
    }

    void Update()
    {
        float currentYPosition = player.position.y;
        if (currentYPosition > highestYPosition)
        {
            highestYPosition = currentYPosition;
            score = Mathf.RoundToInt(highestYPosition);
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24;
        style.normal.textColor = Color.black;

        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + score, style);
    }
}
