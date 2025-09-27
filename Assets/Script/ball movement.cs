using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmovement : MonoBehaviour
{
    public float speed = 5f;   // movement speed
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Add some drag so the ball slows down naturally
        rb.drag = 1f;             // slows linear movement
        rb.angularDrag = 0.5f;    // slows rotation
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        // WASD input
        if (Input.GetKey(KeyCode.W)) moveVertical = 1f;
        if (Input.GetKey(KeyCode.S)) moveVertical = -1f;
        if (Input.GetKey(KeyCode.A)) moveHorizontal = -1f;
        if (Input.GetKey(KeyCode.D)) moveHorizontal = 1f;

        // Create movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Apply force for realistic rolling
        rb.AddForce(movement * speed, ForceMode.Force);
    }
}
