using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] bool verticalMove = false;
    [SerializeField] bool horizontalMove = false;
    [SerializeField] float speed = 4f;
    [SerializeField] float distance = 2f;
    [SerializeField] float offset = 0f;

    // Update is called once per frame
    void Update()
    {
        if (verticalMove)
        {
            transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * speed, distance) + offset);
        }
        if (horizontalMove)
        {
            transform.position = new Vector2(Mathf.PingPong(Time.time * speed, distance) + offset, transform.position.y);
        }

    }
}
