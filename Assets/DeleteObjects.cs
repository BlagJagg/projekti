using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeleteObjects : MonoBehaviour


{
    [SerializeField]
    public GameObject platform;
    // Start is called before the first frame update
    void OnBecameInvisible()
    {
        Destroy(platform);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


