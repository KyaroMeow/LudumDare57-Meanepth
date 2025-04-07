using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsShake : MonoBehaviour
{
    public bool IsShake = true;
    public float shakeMagnitude = 0.1f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        while (IsShake)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.localPosition = originalPosition + new Vector3(x, y, 0);
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
