using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private float deathYLevel = -10f; // The Y level at which the player should die

    private void Update()
    {
        if (transform.position.y < deathYLevel) // Check if player's Y position is below the deathYLevel
        {
            SceneManager.LoadScene("Menu"); // Load the "Menu" scene
        }
    }
}
