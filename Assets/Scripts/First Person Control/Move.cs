using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode runKey = KeyCode.LeftShift;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = Input.GetKey(runKey) ? runSpeed : walkSpeed;

        float inputX = Input.GetAxis("Horizontal") * speed/150;
        float inputZ = Input.GetAxis("Vertical") * speed/150;

        rb.velocity = transform.TransformDirection(new Vector3 (inputX, rb.velocity.y, inputZ));
    }
}
