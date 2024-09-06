using UnityEngine;
using System;
using Unity.VisualScripting;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private int collisionsBeforeExplode; // Number of collisions
    [SerializeField] private float reflectReductionFactor; // Factor to reduce velocity after reflection

    public Action<Collider, Vector3, Vector3> OnCollision; // Event for handling decal creation
    public Action OnExplode; // Event for handling explosion and camera shake

    private Vector3 velocity; // Current velocity
    private float gravity = -9.81f; // Gravity

    private void FixedUpdate()
    {
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
            OnCollision?.Invoke(hitInfo.collider, hitInfo.point, hitInfo.normal);

            if (collisionsBeforeExplode > 0)
            {
                // Reflect the velocity based on the surface normal
                velocity = Vector3.Reflect(velocity, hitInfo.normal);
                float angle = Vector3.Angle(velocity.normalized, hitInfo.normal);
                float reductionFactor = Mathf.Lerp(reflectReductionFactor, 1f, angle / 180f);
                velocity *= reductionFactor;
                transform.position = hitInfo.point;

                collisionsBeforeExplode--;
            }
            else
            {
                OnExplode?.Invoke();

                // Deactivate the cannonball
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
