using UnityEditor;
using UnityEngine;

public class enemyspwan : MonoBehaviour
{
    public GameObject prefab;
    public float repeatTime = 3f;
    public int limit;
    void Start()
    {
        if (limit <= 3)
        {
            InvokeRepeating("Spawn", 2f, repeatTime);
        }
        else
        {
            this.enabled = false;
        }
       
    }
    void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        limit++;
    }
}
