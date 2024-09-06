using UnityEngine;
using System.Collections.Generic;

public class TrajectoryHelper : MonoBehaviour
{
    public int resolution = 300;  // Number of points in the trajectory
    Vector3 gravity = new Vector3(0, -9.81f, 0);  // Default gravity in Unity

    public List<Vector3> CalculateTrajectory(Transform originPoint, float force)
    {
        List<Vector3> trajectoryPoints = new List<Vector3>();
        Vector3 velocity = originPoint.forward * force;
        Vector3 currentPosition = originPoint.position;

        for (int i = 0; i < resolution; i++)
        {
            trajectoryPoints.Add(currentPosition);
            velocity += gravity * Time.fixedDeltaTime;  // Update velocity with gravity
            currentPosition += velocity * Time.fixedDeltaTime;  // Update position with velocity
        }

        return trajectoryPoints;
    }
}
