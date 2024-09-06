using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cannonball))]
public class CannonballExplosionCameraShake : MonoBehaviour
{
    void Start()
    {
        GetComponent<Cannonball>().OnExplode += OnExplode;
    }

    private void OnExplode(Vector3 _)
    {
        CameraShake.instance.Shake();
    }
}
