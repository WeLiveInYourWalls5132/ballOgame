using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller3D : MonoBehaviour
{
    public Transform camera;
    public float speed,boostSpeed;
    private bool isOnGround = false;
    private Rigidbody rigidbody;
    private Vector3 position;

    private float currentSpeed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = boostSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {

            var vel = rigidbody.velocity;
            if(vel.x<0) vel.x = 0;
            rigidbody.velocity = vel;
            rigidbody.AddForce(Vector3.right*currentSpeed*Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var vel = rigidbody.velocity;
            if(vel.x>0) vel.x = 0;
            rigidbody.velocity = vel;
            rigidbody.AddForce(-Vector3.right*currentSpeed*Time.deltaTime);
        }*/

        if (Input.GetKey(KeyCode.UpArrow) ||  Input.GetKey(KeyCode.W))
        {var vel = rigidbody.velocity;
            if(vel.z<0) vel.z = 0;
            rigidbody.velocity = vel;
            rigidbody.AddForce((transform.position - camera.position).normalized *currentSpeed*Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) ||  Input.GetKey(KeyCode.S))
        {var vel = rigidbody.velocity;
            if(vel.z>0) vel.z = 0;
            rigidbody.velocity = vel;
            rigidbody.AddForce(-(transform.position - camera.position).normalized *currentSpeed*Time.deltaTime);
        }
    }
}
