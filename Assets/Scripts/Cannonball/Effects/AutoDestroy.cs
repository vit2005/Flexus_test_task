using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    [SerializeField] float time;

    void Start()
    {
        StartCoroutine(SelfDestroyCoroutine());
    }

    private IEnumerator SelfDestroyCoroutine()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
