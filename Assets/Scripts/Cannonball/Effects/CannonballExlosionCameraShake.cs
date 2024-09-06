using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cannonball))]
public class CannonballExlosionCameraShake : MonoBehaviour
{
    void Start()
    {
        GetComponent<Cannonball>().OnExplode += OnExplode;
    }

    private void OnExplode()
    {
        CameraShake.instance.Shake();
    }
}
