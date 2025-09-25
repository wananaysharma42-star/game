using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBallController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 10f;          // normal speed
    public float sprintMultiplier = 1.8f;  // sprint boost
    public float maxVelocity = 20f;        // cap top speed
    public float groundDrag = 2f;          // smooth stop

    private Rigidbody rb;
    private Vector3 inputDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate; // smoother physics
    }

    void Update()
    {
        // --- Gather Input ---
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        inputDir = new Vector3(h, 0f, v).normalized;

        // --- Optional drag for crisp stopping ---
        rb.drag = IsGrounded() ? groundDrag : 0f;
    }

    void FixedUpdate()
    {
        if (inputDir.sqrMagnitude < 0.01f) return;

        // Sprint if Left Shift held
        float speed = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? sprintMultiplier : 1f);

        Vector3 force = inputDir * speed;

        // Apply force in world space (XZ plane)
        rb.AddForce(force, ForceMode.Acceleration);

        // Cap velocity for consistency
        Vector3 vel = rb.velocity;
        if (vel.magnitude > maxVelocity)
            rb.velocity = vel.normalized * maxVelocity;
    }

    bool IsGrounded()
    {
        // Simple ground check (adjust radius/offset for your sphere)
        return Physics.Raycast(transform.position, Vector3.down, GetComponent<SphereCollider>().radius * 1.1f);
    }
}
