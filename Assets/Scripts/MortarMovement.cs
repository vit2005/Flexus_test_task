using UnityEngine;

// Used on Camera
public class MortarMovement : MonoBehaviour
{
    [SerializeField] Transform capsule;
    public float rotationSpeed = 100f;  // Speed of rotation

    void Update()
    {
        // Get the horizontal and vertical input axes
        float verticalInput = Input.GetAxis("Vertical");   // "Up" and "Down" keys (W/S or Arrow Keys)
        float horizontalInput = Input.GetAxis("Horizontal"); // "Left" and "Right" keys (A/D or Arrow Keys)

        // Rotate around the X-axis (up/down)
        capsule.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);

        // Rotate around the Y-axis (left/right)
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime, Space.World);
    }
}
