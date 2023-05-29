using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("DAAAAAAAA");
            SceneManager.LoadScene("spawn");
            Destroy(player);
        }
    }
}
