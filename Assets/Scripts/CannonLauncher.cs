using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    public GameObject cannonballPrefab; // Cannonball prefab
    public Transform spawnPoint; // Point where cannonball is instantiated
    public ForceController forceController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 direction = spawnPoint.forward;
        float force = forceController.force;
        GameObject cannonball = Instantiate(cannonballPrefab, spawnPoint.position, Quaternion.identity);
        cannonball.GetComponent<Cannonball>().Initialize(direction, force);
    }
}
