using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarTrajectory : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private TrajectoryHelper trajectory;
    [SerializeField] private ForceController forceController;
    [SerializeField] private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.positionCount = trajectory.resolution;
    }

    void Update()
    {
        List<Vector3> var = trajectory.CalculateTrajectory(shootingPoint, forceController.force);
        lineRenderer.SetPositions(var.ToArray());
    }
}
