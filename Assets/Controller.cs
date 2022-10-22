using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private bool isOnGround = false;
    private Rigidbody2D rigidbody2d;
    private Vector3 position;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        position = transform.position;
    }

  
    void Update()
    {
        isOnGround = false;
        var list = Physics2D.OverlapCircleAll(transform.position, 2f);
        foreach (var collider2D in list)
        {
            if (collider2D.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) &&isOnGround)
        {
            rigidbody2d.AddForce(Vector2.up*10,ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
        
            rigidbody2d.AddTorque(-5f);
            if (!isOnGround)
            {
                rigidbody2d.AddForce(Vector2.right*1);
            }
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2d.AddTorque(5f);
            if (!isOnGround)
            {
                rigidbody2d.AddForce(Vector2.left*1);
            }
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("lava death"))
        {
            transform.position = position;
        }

        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            position = transform.position;
        }
    }

}
