using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Sphere;   // the ball
    public Vector3 offset;     // distance between camera and ball
    public float smoothSpeed = 0.125f;  // smoothness factor
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;

        // Desired position = ball position + offset
        Vector3 desiredPosition = Sphere.position + offset;

        // Smoothly move camera towards desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Keep looking at the ball
        transform.LookAt(Sphere);
        
    }
}
