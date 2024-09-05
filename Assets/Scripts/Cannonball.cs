using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float gravity = -9.81f; // Gravity
    private Vector3 velocity; // Current velocity
    private Vector3 initialPosition; // Initial position
    private bool isActive = true; // Whether the cannonball is active

    private void FixedUpdate()
    {
        if (!isActive)
            return;

        Move();
        CheckForCollisions();
    }

    public void Initialize(Vector3 direction, float force)
    {
        initialPosition = transform.position;
        velocity = direction.normalized * force;
    }

    private void Move()
    {
        velocity += new Vector3(0, gravity * Time.fixedDeltaTime, 0);
        transform.position += velocity * Time.fixedDeltaTime;
    }

    private void CheckForCollisions()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position, 1f, velocity.normalized, out hitInfo, velocity.magnitude * Time.fixedDeltaTime))
        {
            // Reflect the velocity based on the surface normal
            velocity = Vector3.Reflect(velocity, hitInfo.normal);

            // Move the cannonball to the hit point
            transform.position = hitInfo.point;

            // Optionally handle damage or effects here

            // Optionally deactivating or stopping the cannonball if needed
            // isActive = false;
        }
    }
}
