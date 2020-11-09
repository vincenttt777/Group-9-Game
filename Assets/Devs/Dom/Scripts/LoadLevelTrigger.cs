using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelTrigger : MonoBehaviour
{
    public int levelToLoad = 1;
    private bool activated = true;

    void Start()
    {
        activated = true;
        StartCoroutine(EnableTrigger());
    }

    IEnumerator EnableTrigger()
    {
        yield return new WaitForSeconds(1f);
        activated = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        
        if (other.transform == Game.GetPlayerTransform())
        {
            activated = true;
            Game.GetGameManager().LoadScene(levelToLoad);
        }
    }
}
