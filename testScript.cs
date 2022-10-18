
using System;
using UnityEngine;

public class testScript : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        speed = 10;
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if(Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
