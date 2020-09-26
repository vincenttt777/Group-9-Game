using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float seconds = 2f;
    private void OnEnable()
    {
        StartCoroutine(DestructionTimer());
    }

    private IEnumerator DestructionTimer()
    {
        yield return new WaitForSecondsRealtime(seconds);
        Destroy(gameObject);
    }
}
