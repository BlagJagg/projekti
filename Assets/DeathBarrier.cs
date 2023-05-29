using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private float deathYLevel = -10f;

    private void Update()
    {
        if (transform.position.y < deathYLevel)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
