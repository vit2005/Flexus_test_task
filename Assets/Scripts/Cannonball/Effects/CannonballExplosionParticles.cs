using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

[RequireComponent(typeof(Cannonball))]
public class CannonballExplosionParticles : MonoBehaviour
{
    [SerializeField] GameObject particles;
    void Start()
    {
        GetComponent<Cannonball>().OnExplode += OnExplode;
    }

    private void OnExplode(Vector3 normal)
    {
        particles.SetActive(true);
        particles.transform.SetParent(null);
        particles.transform.forward = normal;
    }
}
