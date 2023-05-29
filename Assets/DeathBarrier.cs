using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private float deathYLevel = -10f; // The Y level at which the player should die
    [SerializeField] private GameObject player; // Reference to the player object

    private void Update()
    {
        if (player.transform.position.y < deathYLevel) // Check if player's Y position is below the deathYLevel
        {
            Destroy(player); // Delete the player object
            SceneManager.LoadScene("Menu"); // Load the "Menu" scene
        }
    }
}
