using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller3D : MonoBehaviour
{


    private bool isOnGround = false;
    private Rigidbody rigidbody;
    private Vector3 position;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddTorque(Vector3.up*1000);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddTorque(Vector3.up*-1000);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.AddForce(Vector3.forward*100);
        }
    }
}
