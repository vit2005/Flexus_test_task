using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraShake : Singleton<CameraShake>
{
    [SerializeField] private float duration;  // Base duration of the shake
    [SerializeField] private float magnitude; // Magnitude of the shake

    private Vector3 originalPos;
    private float originalFoV;
    private float shakeTimeRemaining; // Time remaining for the shake
    private Camera thisCamera;

    void Start()
    {
        originalPos = transform.localPosition;
        thisCamera = GetComponent<Camera>();
        originalFoV = thisCamera.fieldOfView;
    }

    public void Shake()
    {
        // Add the base duration to the remaining shake time
        shakeTimeRemaining += duration;

        // Start the shake coroutine if it's not already running
        if (!IsInvoking(nameof(ShakeCoroutine)))
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    private IEnumerator ShakeCoroutine()
    {
        while (shakeTimeRemaining > 0)
        {
            float random = Random.Range(-1f, 1f) * magnitude;

            thisCamera.fieldOfView += random;

            shakeTimeRemaining -= Time.deltaTime;

            yield return null; // Wait until the next frame
        }

        thisCamera.fieldOfView = originalFoV;
        shakeTimeRemaining = 0f; // Reset the shake time remaining
    }
}
