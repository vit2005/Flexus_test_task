using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cannonball))]
public class CannonballPainter : MonoBehaviour
{

    public Color paintColor;
    public float radius = 1;
    public float strength = 1;
    public float hardness = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Cannonball>().OnCollision += OnCollision;
    }

    private void OnCollision(Collider collider, Vector3 point, Vector3 normal)
    {
        Paintable p = collider.GetComponent<Paintable>();
        if (p != null)
        {
            PaintManager.instance.paint(p, point, radius, hardness, strength, paintColor);
        }
    }
}
