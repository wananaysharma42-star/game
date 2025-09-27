using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // the ball
    public Vector3 offset = new Vector3(0f , 3f , -6f);     // distance between camera and ball
    public float smoothSpeed = 0.125f;  // smoothness factor
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position
        Vector3 desiredPosition = target.position + target.transform.rotation * offset;

        // Smooth follow
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Make the camera look at the ball
        transform.LookAt(target);
        
        
    }
}
