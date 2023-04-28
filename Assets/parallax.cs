using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public float speed;
    public Transform target;

    private float length, startpos;

    private void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startpos = transform.position.x;
    }

    private void FixedUpdate()
    {
        float dist = (target.position.x * speed);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}