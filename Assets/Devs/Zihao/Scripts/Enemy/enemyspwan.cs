using UnityEditor;
using UnityEngine;

public class enemyspwan : MonoBehaviour
{
    public GameObject prefab;
    public float repeatTime = 3f;
    void Start()
    {
        InvokeRepeating("Spawn", 2f, repeatTime);
    }
    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
