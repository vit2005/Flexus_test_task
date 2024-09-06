using UnityEngine;
using System;
using Unity.VisualScripting;

public class Cannonball : MonoBehaviour
{
    public float gravity = -9.81f; // Gravity
    private Vector3 velocity; // Current velocity
    private bool isActive = true; // Whether the cannonball is active
    private int collisionCount = 0; // Number of collisions
    public float reflectReductionFactor; // Factor to reduce velocity after reflection
    public Action<Vector3, Vector3> OnCollision; // Event for handling decal creation
    public Action OnExplode; // Event for handling explosion and camera shake

    private void FixedUpdate()
    {
        if (!isActive)
            return;

        Move();
        CheckForCollisions();
    }

    public void Initialize(Vector3 direction, float force)
    {
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
        if (Physics.SphereCast(transform.position, 0.2f, velocity.normalized, out hitInfo, velocity.magnitude * Time.fixedDeltaTime))
        {
            // Handle the first collision
            if (collisionCount == 0)
            {
                // Reflect the velocity based on the surface normal
                velocity = Vector3.Reflect(velocity, hitInfo.normal);
                float angle = Vector3.Angle(velocity.normalized, hitInfo.normal);
                float reductionFactor = Mathf.Lerp(reflectReductionFactor, 1f, angle / 180f);
                velocity *= reductionFactor;

                // Move the cannonball to the hit point
                transform.position = hitInfo.point;

                // Trigger the OnCollision event for decal creation
                OnCollision?.Invoke(hitInfo.point, hitInfo.normal);

                DecalManager.instance.RenderDecal(hitInfo.point, hitInfo.normal);

                collisionCount++;
            }
            else
            {
                // Trigger the OnExplode event for explosion and camera shake
                OnExplode?.Invoke();

                // Deactivate the cannonball
                isActive = false;
                Destroy(gameObject); // Optionally destroy the cannonball object
            }
        }
    }
}
