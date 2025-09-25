using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 6f, -8f);
    [Range(0f, 1f)]
    public float smoothTime = 0.15f;   // lower = snappier, higher = floatier
    public float rotationSmooth = 5f;  // how quickly camera faces target direction

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (!target) return;

        // Smooth position
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);

        // Smoothly rotate to look at target
        Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotationSmooth * Time.deltaTime);
    }
}
