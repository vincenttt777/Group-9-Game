using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActiveStone : MonoBehaviour
{
    public GameObject sphere;
    public GameObject stone;
    Vector3 originalPos;
    public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        sphere = GameObject.Find("FallingStone/Sphere");
        sphere.SetActive(false);

        if (respawn == null)
            respawn = GameObject.FindWithTag("Traps");

        originalPos = new Vector3(respawn.transform.position.x, respawn.transform.position.y, respawn.transform.position.z);
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        sphere.SetActive(true);
        StartCoroutine(stonedisappear());
        if (other.transform == Game.GetPlayerTransform())
        {
            stone = GameObject.FindWithTag("Traps");
            stone.transform.DOMoveY(1f, 0.6f);
        }
    }

    public IEnumerator stonedisappear()
    {
        yield return new WaitForSeconds(1.5f);
        respawn.transform.position = originalPos;
        sphere.SetActive(false);
    }
}
