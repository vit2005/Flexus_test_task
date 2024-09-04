using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeController : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private MortarTrajectory trajectory;
    [SerializeField] private ForceController forceController;
    [SerializeField] private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = trajectory.resolution;
    }

    // Update is called once per frame
    void Update()
    {
        List<Vector3> var = trajectory.CalculateTrajectory(shootingPoint, forceController.force);
        lineRenderer.SetPositions(var.ToArray());
    }
}
