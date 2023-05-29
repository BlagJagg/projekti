using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private GameObject player;



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            SceneManager.LoadScene("spawn");
        Debug.LogError("not colliding");
        Destroy(player);
    }
}
