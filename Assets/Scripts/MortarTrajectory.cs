using UnityEngine;
using System.Collections.Generic;

public class MortarTrajectory : MonoBehaviour
{
    public int resolution = 30;  // Number of points in the trajectory
    public float timeStep = 0.1f; // Time between points

    public List<Vector3> CalculateTrajectory(Transform originPoint, float force)
    {
        List<Vector3> trajectoryPoints = new List<Vector3>();

        // Initial velocity
        Vector3 velocity = originPoint.forward * force;

        // Gravity vector
        Vector3 gravity = Vector3.down * 9.8f;  // Default gravity in Unity

        // Initial position
        Vector3 currentPosition = originPoint.position;

        for (int i = 0; i < resolution; i++)
        {
            // Add the current position to the trajectory points list
            trajectoryPoints.Add(currentPosition);

            // Calculate the next position
            velocity += gravity * timeStep;  // Update velocity with gravity
            currentPosition += velocity * timeStep;  // Update position with velocity
        }

        return trajectoryPoints;
    }
}
